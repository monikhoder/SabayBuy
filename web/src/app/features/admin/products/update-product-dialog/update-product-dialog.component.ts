import { Component, inject, OnInit } from '@angular/core';
import { MatDialogRef, MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ShopServices } from '../../../../core/services/shop.service';
import { categoryParams } from '../../../../shared/models/categoryParams';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AdminService } from '../../../../core/services/admin.service';
import { FileUploadService } from '../../../../core/services/file-upload.service';
import { CommonModule } from '@angular/common';
import { Category } from '../../../../shared/models/category';
import { Product } from '../../../../shared/models/product';

@Component({
  selector: 'app-update-product-dialog',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, CommonModule],
  templateUrl: './update-product-dialog.component.html',
  styleUrl: './update-product-dialog.component.scss',
})
export class UpdateProductDialogComponent implements OnInit {

  private dialogRef = inject(MatDialogRef<UpdateProductDialogComponent>);
  public product = inject<Product>(MAT_DIALOG_DATA);
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
  matchingCategoryId: string = '';

  ngOnInit(): void {
    this.imagePreview = this.product.baseImageUrl || null;
    this.initializeForm();
    this.loadParentCategories();
  }

  initializeForm() {
    this.productForm = this.fb.group({
      productName: [this.product.productName, Validators.required],
      brand: [this.product.brand, Validators.required],
      categoryId: [''], // Will be set after categories load if matched
      description: [this.product.description || ''],
      baseImageUrl: [this.product.baseImageUrl || '']
    });
  }

  loadParentCategories(): void {
    this.categoryParams.isParent = true;
    this.categoryParams.pageSize = 100;
    this.shopService.getCategories(this.categoryParams).subscribe({
      next: (response) => {
        this.parentCategories = response.data;
        this.findMatchingCategory();
      },
      error: (error) => this.snack.error('Failed to load categories: ' + error.message)
    });
  }

  findMatchingCategory(): void {
    let matchedId = '';
    for (const category of this.parentCategories) {
      if (category.categoryName === this.product.categoryName) {
        matchedId = category.id;
        break;
      }
      if (category.subCategories) {
        for (const sub of category.subCategories) {
          if (sub.categoryName === this.product.categoryName) {
            matchedId = sub.id;
            break;
          }
        }
      }
      if (matchedId) break;
    }

    if (matchedId) {
      this.productForm.patchValue({ categoryId: matchedId });
    }
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
          this.updateProduct();
        },
        error: (error) => {
          this.loading = false;
          this.snack.error('Failed to upload image: ' + error.message);
        }
      });
    } else {
      this.updateProduct();
    }
  }

  private updateProduct() {
    this.adminService.updateProduct(this.product.id, this.productForm.value).subscribe({
      next: (product) => {
        this.loading = false;
        this.snack.success('Product updated successfully');
        this.dialogRef.close(product);
      },
      error: (error) => {
        this.loading = false;
        this.snack.error('Failed to update product');
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
