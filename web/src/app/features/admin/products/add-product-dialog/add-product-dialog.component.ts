import { Component, inject, OnInit } from '@angular/core';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { ShopServices } from '../../../../core/services/shop.service';
import { categoryParams } from '../../../../shared/models/categoryParams';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AdminService } from '../../../../core/services/admin.service';
import { FileUploadService } from '../../../../core/services/file-upload.service';
import { CommonModule } from '@angular/common';
import { Category } from '../../../../shared/models/category';

@Component({
  selector: 'app-add-product-dialog',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, CommonModule],
  templateUrl: './add-product-dialog.component.html',
  styleUrl: './add-product-dialog.component.scss',
})
export class AddProductDialogComponent implements OnInit {

  private dialogRef = inject(MatDialogRef<AddProductDialogComponent>);
  private shopService = inject(ShopServices);
  private adminService = inject(AdminService);
  private fileService = inject(FileUploadService);
  private snack = inject(SnackbarService);
  private fb = inject(FormBuilder);

  parentCategories: Category[] = [];
  categoryParams = new categoryParams();
  productForm: FormGroup = new FormGroup({});
  imagePreview: string | null = null;
  selectedFile: File | null = null;
  loading = false;

  ngOnInit(): void {
    this.initializeForm();
    this.loadParentCategories();
  }

  initializeForm() {
    this.productForm = this.fb.group({
      productName: ['', Validators.required],
      brand: ['', Validators.required],
      categoryId: ['', Validators.required],
      description: [''],
      baseImageUrl: ['']
    });
  }

  loadParentCategories(): void {
    this.categoryParams.isParent = true;
    this.categoryParams.pageSize = 100;
    this.shopService.getCategories(this.categoryParams).subscribe({
      next: (response) => {
        this.parentCategories = response.data;
      },
      error: (error) => this.snack.error('Failed to load categories: ' + error.message)
    });
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit() {
    if (this.productForm.invalid) {
      this.snack.error('Please fill in all required fields');
      return;
    }

    this.loading = true;

    if (this.selectedFile) {
      this.fileService.imageUpload(this.selectedFile).subscribe({
        next: (response) => {
          this.productForm.patchValue({ baseImageUrl: response.url });
          this.createProduct();
        },
        error: (error) => {
          this.loading = false;
          this.snack.error('Failed to upload image: ' + error.message);
        }
      });
    } else {
      this.createProduct();
    }
  }

  private createProduct() {
    this.adminService.addProduct(this.productForm.value).subscribe({
      next: (product) => {
        this.loading = false;
        this.snack.success('Product added successfully');
        this.dialogRef.close(product);
      },
      error: (error) => {
        this.loading = false;
        this.snack.error('Failed to add product');
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
