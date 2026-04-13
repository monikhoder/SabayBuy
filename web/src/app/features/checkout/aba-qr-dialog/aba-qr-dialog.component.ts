import { Component, inject, OnInit, OnDestroy, effect } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { Router, TitleStrategy } from '@angular/router';
import { SignalrService } from '../../../core/services/signalr.service';

@Component({
  selector: 'app-aba-qr-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, CommonModule],
  template: `
    <h2 mat-dialog-title class="text-center text-blue-900 font-bold">
      Pay with ABA PayWay
    </h2>

    <mat-dialog-content class="flex flex-col items-center justify-center p-4">
      <p class="mb-4 text-gray-600">Please scan the KHQR below to complete your purchase</p>

      <div class="flex items-center justify-center mb-4 relative">
        <div
          class="border-2 border-blue-500 rounded-lg p-4 shadow-sm inline-flex items-center justify-center bg-white relative"
          [class.opacity-40]="isExpired"
        >
          <img [src]="data.qrImage" alt="ABA KHQR" class="w-64 h-64 object-contain mx-auto" />

          <div *ngIf="isExpired" class="absolute inset-0 flex items-center justify-center bg-white/80">
            <span class="text-red-600 font-bold text-xl">QR Code Expired</span>
          </div>
        </div>
      </div>

      <p class="mt-2 text-lg">
        Total Amount: <span class="font-bold text-green-600">\${{ signalrService.orderSignal()?.total ||0 }}</span>
      </p>

      <p class="mt-2 text-md font-medium" [ngClass]="isExpired ? 'text-red-500' : 'text-blue-600'">
        Time remaining: {{ formatTime(timeLeft) }}
      </p>
    </mat-dialog-content>

    <mat-dialog-actions class="pb-4 justify-center">
      <button mat-stroked-button color="warn" (click)="closeDialog()">
        {{ isExpired ? 'Close' : 'Cancel' }}
      </button>
    </mat-dialog-actions>
  `,
})
export class AbaQrDialogComponent implements OnInit, OnDestroy {
  data = inject(MAT_DIALOG_DATA);
  dialogRef = inject(MatDialogRef<AbaQrDialogComponent>);
  router = inject(Router);
  signalrService = inject(SignalrService)

  timeLeft: number = 180;
  timerInterval: any;
  isExpired: boolean = false;

  constructor() {

    effect(() => {
      const orderSignal = this.signalrService.orderSignal();
      if (orderSignal !== null) {
        this.handlePaymentSuccess();
      }
    });
  }

  ngOnInit() {
    this.startTimer();
  }

  ngOnDestroy() {
    this.clearTimer();
  }

  startTimer() {
    this.timerInterval = setInterval(() => {
      if (this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.isExpired = true;
        this.clearTimer();
      }
    }, 1000);
  }

  clearTimer() {
    if (this.timerInterval) {
      clearInterval(this.timerInterval);
    }
  }

  formatTime(seconds: number): string {
    const m = Math.floor(seconds / 60);
    const s = seconds % 60;
    return `${m < 10 ? '0' : ''}${m}:${s < 10 ? '0' : ''}${s}`;
  }

  closeDialog() {
    this.dialogRef.close(false);
  }

  handlePaymentSuccess() {
    const orderId = this.signalrService.orderSignal()?.id;
    this.clearTimer();
    this.dialogRef.close(true);
    // Clear signal
    this.signalrService.orderSignal.set(null);
    this.router.navigate(['/checkout/success'], { state: { orderId } });
  }
}