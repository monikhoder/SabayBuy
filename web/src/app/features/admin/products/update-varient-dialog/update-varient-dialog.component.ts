import { Component, inject, OnInit } from '@angular/core';
import { MatDialogRef, MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, FormArray, ReactiveFormsModule, Validators } from '@angular/forms';
import { AdminService } from '../../../../core/services/admin.service';
import { FileUploadService } from '../../../../core/services/file-upload.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { CommonModule } from '@angular/common';
import { ProductVariant } from '../../../../shared/models/product';

export interface UpdateVariantDialogData {
  variant: ProductVariant;
  productName: string;
}

@Component({
  selector: 'app-update-varient-dialog',
  standalone: true,
  imports: [MatDialogModule, ReactiveFormsModule, CommonModule],
  templateUrl: './update-varient-dialog.component.html',
  styleUrl: './update-varient-dialog.component.scss',
})
export class UpdateVarientDialogComponent implements OnInit {
  private dialogRef = inject(MatDialogRef<UpdateVarientDialogComponent>);
  public data = inject<UpdateVariantDialogData>(MAT_DIALOG_DATA);
  private adminService = inject(AdminService);
  private fileService = inject(FileUploadService);
  private snack = inject(SnackbarService);
  private fb = inject(FormBuilder);

  variantForm: FormGroup = new FormGroup({});
  imagePreview: string | null = null;
  selectedFile: File | null = null;
  loading = false;

  ngOnInit(): void {
    this.imagePreview = this.data.variant.imageUrl || null;
    this.initializeForm();
  }

  initializeForm() {
    this.variantForm = this.fb.group({
      sku: [this.data.variant.sku, Validators.required],
      price: [this.data.variant.price, [Validators.required, Validators.min(0.01)]],
      stockQuantity: [this.data.variant.stockQuantity, [Validators.required, Validators.min(0)]],
      isActive: [true, Validators.required], // Added IsActive as per UpdateProductVariantDto
      imageUrl: [this.data.variant.imageUrl || ''],
      attributes: this.fb.array([])
    });

    if (this.data.variant.attributes && this.data.variant.attributes.length > 0) {
      this.data.variant.attributes.forEach(attr => {
        this.attributes.push(this.fb.group({
          attributeName: [attr.attributeName, Validators.required],
          attributeValue: [attr.attributeValue, Validators.required]
        }));
      });
    }
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
          this.updateVariant();
        },
        error: (error) => {
          this.loading = false;
          this.snack.error('Failed to upload image: ' + error.message);
        }
      });
    } else {
      this.updateVariant();
    }
  }

  private updateVariant() {
    const variantPayload = this.variantForm.value;

    this.adminService.updateVariant(this.data.variant.id, variantPayload).subscribe({
      next: (variant) => {
        this.loading = false;
        this.snack.success('Variant updated successfully');
        this.dialogRef.close(variant);
      },
      error: (error) => {
        this.loading = false;
        this.snack.error('Failed to update variant : ' + error.error);
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
