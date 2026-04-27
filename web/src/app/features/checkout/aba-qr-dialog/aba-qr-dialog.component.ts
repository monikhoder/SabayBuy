import { Component, inject, OnInit, OnDestroy, effect } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SignalrService } from '../../../core/services/signalr.service';

interface AbaQrDialogData {
  qrImage: string;
  totalAmount: string;
  tran_id: string;
  orderId: string;
}

@Component({
  selector: 'app-aba-qr-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, CommonModule],
  template: `
    <mat-dialog-content class="!p-0">
      <div class="bg-gray-50 px-5 py-6">
        <div class="mx-auto w-full max-w-[340px] overflow-hidden rounded-[24px] bg-white shadow-xl shadow-gray-200">
          <div class="relative flex h-[58px] items-center justify-center bg-red-600">
            <span class="text-2xl font-bold tracking-normal text-white">KHQR</span>
          </div>

          <div class="relative px-12 pb-10 pt-7">
            <div class="absolute right-0 top-0 h-0 w-0 border-l-[28px] border-t-[28px] border-l-transparent border-t-red-600"></div>

            <div>
              <p class="text-xs font-medium uppercase tracking-normal text-slate-900">SABAYBUY</p>
              <div class="mt-2 flex items-end gap-3">
                <span class="text-3xl font-bold leading-none text-slate-950">{{ formattedAmount }}</span>
                <span class="pb-1 text-sm font-medium text-slate-900">USD</span>
              </div>
            </div>

            <div class="-mx-12 my-7 border-t border-dashed border-gray-300"></div>

            <div class="relative mx-auto flex aspect-square w-full max-w-[244px] items-center justify-center">
              <img
                [src]="data.qrImage"
                alt="ABA KHQR"
                class="h-full w-full object-contain"
                [class.opacity-30]="isExpired"
              />

              <div class="absolute inset-0 flex items-center justify-center pointer-events-none">
                <span class="flex h-12 w-12 items-center justify-center rounded-full border-4 border-white bg-slate-950 text-3xl font-semibold text-white shadow-md">
                  $
                </span>
              </div>

              <div *ngIf="isExpired" class="absolute inset-0 flex items-center justify-center bg-white/85">
                <span class="rounded-full bg-red-50 px-4 py-2 text-sm font-bold text-red-600">
                  QR Code Expired
                </span>
              </div>
            </div>
          </div>
        </div>

        <div class="mx-auto mt-5 max-w-[340px] text-center">
          <p class="text-sm font-medium" [ngClass]="isExpired ? 'text-red-500' : 'text-slate-700'">
            Time remaining: {{ formatTime(timeLeft) }}
          </p>
          <p class="mt-1 break-all text-xs text-slate-500">Tran ID: {{ data.tran_id }}</p>
        </div>
      </div>
    </mat-dialog-content>

    <mat-dialog-actions class="!m-0 justify-center bg-gray-50 px-5 pb-5 pt-0">
      <button mat-stroked-button color="warn" (click)="closeDialog()">
        {{ isExpired ? 'Close' : 'Cancel' }}
      </button>
    </mat-dialog-actions>
  `,
  })
export class AbaQrDialogComponent implements OnInit, OnDestroy {
  data = inject<AbaQrDialogData>(MAT_DIALOG_DATA);
  dialogRef = inject(MatDialogRef<AbaQrDialogComponent>);
  router = inject(Router);
  signalrService = inject(SignalrService)

  timeLeft: number = 180;
  timerInterval: any;
  isExpired: boolean = false;

  get formattedAmount(): string {
    const amount = Number(this.data.totalAmount);
    return Number.isFinite(amount) ? amount.toFixed(2) : this.data.totalAmount;
  }

  constructor() {

    effect(() => {
      const orderSignal = this.signalrService.orderSignal();
      if (orderSignal !== null && orderSignal.paymentIntentId === this.data.tran_id) {
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
    const orderId = this.signalrService.orderSignal()?.id ?? this.data.orderId;
    this.clearTimer();
    this.dialogRef.close(true);
    // Clear signal
    this.signalrService.orderSignal.set(null);
    this.router.navigate(['/checkout/success'], { state: { orderId } });
  }
}
