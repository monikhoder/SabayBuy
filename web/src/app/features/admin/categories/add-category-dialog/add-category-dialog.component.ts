import { Component, inject, OnInit } from '@angular/core';
import { MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AdminService } from '../../../../core/services/admin.service';
import { FileUploadService } from '../../../../core/services/file-upload.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { AddCategory, Category } from '../../../../shared/models/category';
import { categoryParams } from '../../../../shared/models/categoryParams';

@Component({
  selector: 'app-add-category-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, ReactiveFormsModule, CommonModule, MatProgressSpinnerModule],
  templateUrl: './add-category-dialog.component.html',
  styleUrl: './add-category-dialog.component.scss'
})
export class AddCategoryDialogComponent implements OnInit {
  dialogRef = inject(MatDialogRef<AddCategoryDialogComponent>);
  adminService = inject(AdminService);
  fileUploadService = inject(FileUploadService);
  snack = inject(SnackbarService);
  fb = inject(FormBuilder);

  categoryForm: FormGroup;
  parentCategories: Category[] = [];
  isLoading = false;
  isUploadingIcon = false;
  selectedFile: File | null = null;
  iconUrl: string | null = null;
  categoryParams = new categoryParams();

  constructor() {
    this.categoryForm = this.fb.group({
      categoryName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      parentCategoryId: [''],
      icon: ['']
    });
  }

  ngOnInit(): void {
    this.loadParentCategories();
  }

  loadParentCategories(): void {
    this.categoryParams.isParent = true;
    this.categoryParams.pageSize = 100
    this.adminService.getCategories(this.categoryParams).subscribe({
      next: (response) => {
        this.parentCategories = response.data;
      },
      error: (error) => this.snack.error('Failed to load parent categories: ' + error.message)
    });
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];

      // Validate file type
      if (!this.selectedFile.type.startsWith('image/')) {
        this.snack.error('Only image files are allowed');
        this.selectedFile = null;
        input.value = '';
        return;
      }

      // Preview file
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
    const categoryData: AddCategory = {
      categoryName: formValue.categoryName,
      parentCategoryId: formValue.parentCategoryId || null,
      icon: formValue.icon || null
    };

    this.adminService.addCategory(categoryData).subscribe({
      next: (category) => {
        this.isLoading = false;
        this.dialogRef.close(category);
      },
      error: (error) => {
        this.isLoading = false;
        console.error('Failed to add category:', error);
        
        let errorMessage = 'An error occurred';
        if (error.error) {
          if (typeof error.error === 'string') {
            errorMessage = error.error;
          } else if (error.error.errors) {
            errorMessage = Object.values(error.error.errors).flat().join(', ');
          } else if (error.error.message) {
            errorMessage = error.error.message;
          }
        } else {
          errorMessage = error.message;
        }
        
        this.snack.error('Failed to add category: ' + errorMessage);
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
