import { Component, inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AdminService } from '../../../../core/services/admin.service';
import { FileUploadService } from '../../../../core/services/file-upload.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { AddCategory, Category } from '../../../../shared/models/category';

@Component({
  selector: 'app-update-category-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, ReactiveFormsModule, CommonModule, MatProgressSpinnerModule],
  templateUrl: './update-category-dialog.component.html',
  styleUrl: './update-category-dialog.component.scss'
})
export class UpdateCategoryDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<UpdateCategoryDialogComponent>);
  data = inject<Category>(MAT_DIALOG_DATA);
  adminService = inject(AdminService);
  fileUploadService = inject(FileUploadService);
  snack = inject(SnackbarService);
  fb = inject(FormBuilder);

  categoryForm: FormGroup;
  isLoading = false;
  isUploadingIcon = false;
  selectedFile: File | null = null;
  iconUrl: string | null = null;

  constructor() {
    this.categoryForm = this.fb.group({
      categoryName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      icon: ['']
    });
  }

  ngOnInit(): void {
    if (this.data) {
      this.categoryForm.patchValue({
        categoryName: this.data.categoryName,
        icon: this.data.icon
      });
      this.iconUrl = this.data.icon || null;
    }
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];

      if (!this.selectedFile.type.startsWith('image/')) {
        this.snack.error('Only image files are allowed');
        this.selectedFile = null;
        input.value = '';
        return;
      }

      const reader = new FileReader();
      reader.onload = (e) => {
        this.iconUrl = e.target?.result as string;
      };
      reader.readAsDataURL(this.selectedFile);
    }
  }

  uploadIcon(): void {
    if (!this.selectedFile) return;

    this.isUploadingIcon = true;
    this.fileUploadService.imageUpload(this.selectedFile).subscribe({
      next: (response) => {
        this.categoryForm.patchValue({ icon: response.url });
        this.isUploadingIcon = false;
        this.snack.success('Icon uploaded successfully');
      },
      error: (error) => {
        this.isUploadingIcon = false;
        this.snack.error('Failed to upload icon: ' + error.message);
      }
    });
  }

  onSubmit(): void {
    if (this.categoryForm.invalid) {
      this.categoryForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;
    const formValue = this.categoryForm.value;
    const updateData: AddCategory = {
      categoryName: formValue.categoryName,
      icon: formValue.icon || null,
      parentCategoryId: this.data.parentCategoryId
    };

    this.adminService.updateCategory(this.data.id, updateData).subscribe({
      next: (category) => {
        this.isLoading = false;
        this.dialogRef.close(category);
      },
      error: (error) => {
        this.isLoading = false;
        this.snack.error('Failed to update category: ' + (error.error));
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
