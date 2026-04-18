import { Component, inject, OnInit } from '@angular/core';
import { MatDialogRef, MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormArray, ReactiveFormsModule, Validators } from '@angular/forms';
import { AdminService } from '../../../../core/services/admin.service';
import { FileUploadService } from '../../../../core/services/file-upload.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { CommonModule } from '@angular/common';
import { Product } from '../../../../shared/models/product';

@Component({
  selector: 'app-add-varient-dialog',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, CommonModule],
  templateUrl: './add-varient-dialog.component.html',
  styleUrl: './add-varient-dialog.component.scss',
})
export class AddVarientDialogComponent implements OnInit {
  private dialogRef = inject(MatDialogRef<AddVarientDialogComponent>);
  public product = inject<Product>(MAT_DIALOG_DATA);
  private adminService = inject(AdminService);
  private fileService = inject(FileUploadService);
  private snack = inject(SnackbarService);
  private fb = inject(FormBuilder);

  variantForm: FormGroup = new FormGroup({});
  imagePreview: string | null = null;
  selectedFile: File | null = null;
  loading = false;

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.variantForm = this.fb.group({
      sku: ['', Validators.required],
      price: [ [Validators.required, Validators.min(0.01)]],
      stockQuantity: [[Validators.required, Validators.min(0)]],
      imageUrl: [''],
      attributes: this.fb.array([])
    });
  }

  get attributes() {
    return this.variantForm.get('attributes') as FormArray;
  }

  addAttribute() {
    this.attributes.push(this.fb.group({
      attributeName: ['', Validators.required],
      attributeValue: ['', Validators.required]
    }));
  }

  removeAttribute(index: number) {
    this.attributes.removeAt(index);
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
    if (this.variantForm.invalid) {
      this.snack.error('Please fill in all required fields');
      return;
    }

    this.loading = true;

    if (this.selectedFile) {
      this.fileService.imageUpload(this.selectedFile).subscribe({
        next: (response) => {
          this.variantForm.patchValue({ imageUrl: response.url });
          this.createVariant();
        },
        error: (error) => {
          this.loading = false;
          this.snack.error('Failed to upload image: ' + error.message);
        }
      });
    } else {
      this.createVariant();
    }
  }

  private createVariant() {
    const variantPayload = this.variantForm.value;

    this.adminService.addProductVariant(variantPayload, this.product.id).subscribe({
      next: (variant) => {
        this.loading = false;
        this.snack.success('Variant and attributes added successfully');
        this.dialogRef.close(variant);
      },
      error: (error) => {
        this.loading = false;
        this.snack.error('Failed to add variant : ' + error.error );
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}

