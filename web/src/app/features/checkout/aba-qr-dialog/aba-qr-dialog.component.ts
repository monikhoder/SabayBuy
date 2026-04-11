import { Component, inject, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-aba-qr-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, CommonModule],
  template: `<h2 mat-dialog-title class="text-center text-blue-900 font-bold">
      Pay with ABA PayWay
    </h2>

    <mat-dialog-content class="flex flex-col items-center justify-center p-4">
      <p class="mb-4 text-gray-600">Please scan the KHQR below to complete your purchase</p>

      <div class="flex items-center justify-center mb-4">
        <div
          class="border-2 border-blue-500 rounded-lg p-4 shadow-sm inline-flex items-center justify-center bg-white"
        >
          <img [src]="data.qrImage" alt="ABA KHQR" class="w-64 h-64 object-contain mx-auto" />
        </div>
      </div>

      <p class="mt-4 text-lg">
        Total Amount: <span class="font-bold text-green-600">\${{ data.totalAmount }}</span>
      </p>
    </mat-dialog-content>

    <mat-dialog-actions class="pb-4">
      <button mat-stroked-button color="warn" (click)="closeDialog()">Cancel</button>
      <button mat-flat-button color="primary" (click)="checkPaymentStatus()">I have paid</button>
    </mat-dialog-actions>`,
})
export class AbaQrDialogComponent {
  private router = inject(Router);

  constructor(
    public dialogRef: MatDialogRef<AbaQrDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { qrImage: string; totalAmount: number },
  ) {}

  closeDialog(): void {
    this.dialogRef.close('cancelled');
  }

  checkPaymentStatus(): void {
    this.dialogRef.close('success');
  }
}
