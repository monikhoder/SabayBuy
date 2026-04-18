import { Component, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { AdminService } from '../../../../core/services/admin.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';

export interface DeleteDialogData {
  id: string;
  type: 'product' | 'variant';
  name: string;
}

@Component({
  selector: 'app-delete-product-dialog',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './delete-product-dialog.component.html',
  styleUrl: './delete-product-dialog.component.scss',
})
export class DeleteProductDialogComponent {
  dialogRef = inject(MatDialogRef<DeleteProductDialogComponent>);
  data = inject<DeleteDialogData>(MAT_DIALOG_DATA);
  adminService = inject(AdminService);
  snack = inject(SnackbarService);
  loading = false;

  closeDialog() {
    this.dialogRef.close(false);
  }

  confirmDelete() {
    this.loading = true;
    if (this.data.type === 'product') {
      this.adminService.deleteProduct(this.data.id).subscribe({
        next: () => {
          this.snack.success('Product deleted successfully');
          this.dialogRef.close(true);
        },
        error: (err) => {
          this.loading = false;
          this.snack.error('Failed to delete product: ' + err.message);
        }
      });
    } else if (this.data.type === 'variant') {
      this.adminService.deleteVariant(this.data.id).subscribe({
        next: () => {
          this.snack.success('Variant deleted successfully');
          this.dialogRef.close(true);
        },
        error: (err) => {
          this.loading = false;
          this.snack.error('Failed to delete variant: ' + err.message);
        }
      });
    }
  }
}

