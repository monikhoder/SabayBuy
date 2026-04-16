import { Component, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AdminService } from '../../../../core/services/admin.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';
import { Category } from '../../../../shared/models/category';

@Component({
  selector: 'app-delete-category-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, CommonModule, MatProgressSpinnerModule],
  templateUrl: './delete-category-dialog.component.html',
  styleUrl: './delete-category-dialog.component.scss'
})
export class DeleteCategoryDialogComponent {
  dialogRef = inject(MatDialogRef<DeleteCategoryDialogComponent>);
  data = inject<Category>(MAT_DIALOG_DATA);
  adminService = inject(AdminService);
  snack = inject(SnackbarService);

  isLoading = false;

  onConfirm(): void {
    this.isLoading = true;
    this.adminService.deleteCategory(this.data.id).subscribe({
      next: () => {
        this.isLoading = false;
        this.dialogRef.close(true);
      },
      error: (err) => {
        this.isLoading = false;
        console.error('Failed to delete category:', err);
        
        let errorMessage = 'Failed to delete category';
        
        if (err.status === 200) {
          this.dialogRef.close(true);
          return;
        }

        if (err.error) {
          if (typeof err.error === 'string') {
              try {
                  const parsedError = JSON.parse(err.error);
                  errorMessage = parsedError.message || parsedError.title || err.error;
              } catch (e) {
                  errorMessage = err.error;
              }
          } else if (err.error.message) {
              errorMessage = err.error.message;
          } else if (err.error.errors) {
              errorMessage = Object.values(err.error.errors).flat().join(', ');
          }
        } else if (err.message) {
            errorMessage = err.message;
        }
        this.snack.error(errorMessage);
      }
    });
  }

  closeDialog() {
    this.dialogRef.close(false);
  }
}
