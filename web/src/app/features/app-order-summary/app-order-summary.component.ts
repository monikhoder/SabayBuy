import { Component, inject, signal } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { RouterLink } from '@angular/router';
import { Location } from '@angular/common';
import { CheckoutService } from '../../core/services/checkout.service';
import { MatDialog } from '@angular/material/dialog';
import { AbaQrDialogComponent } from '../checkout/aba-qr-dialog/aba-qr-dialog.component';

@Component({
  selector: 'app-app-order-summary',
  imports: [RouterLink, AbaQrDialogComponent],
  templateUrl: './app-order-summary.component.html',
  styleUrl: './app-order-summary.component.scss',
})
export class AppOrderSummaryComponent {
  cartService = inject(CartService);
  checkoutService = inject(CheckoutService);
  location = inject(Location);
  dialog = inject(MatDialog);

  qrCodeImage = signal<string | null>(null);
  isProcessing = signal<boolean>(false);



  onCheckoutSubmit() {
    this.isProcessing.set(true);

    this.checkoutService.createPaymentIntent().subscribe({
      next: (response: any) => {
        this.isProcessing.set(false);

        if (this.checkoutService.selectedPaymentMethod() === 'aba' && response.qrImage) {
           // 3. បើក Dialog ជំនួសឱ្យការប្រើ Signal បង្ហាញលើទំព័រ
           this.openAbaQrDialog(response.qrImage);
        }
        else if (this.checkoutService.selectedPaymentMethod() === 'cod') {
           console.log('Order placed with COD');
        }
      },
      error: (error) => {
        this.isProcessing.set(false);
        console.error('Error during checkout', error);
      }
    });
  }
  openAbaQrDialog(qrImageBase64: string) {
    const dialogRef = this.dialog.open(AbaQrDialogComponent, {
      width: '400px', // កំណត់ទំហំ Popup
      disableClose: true, // ការពារកុំឱ្យចុចខាងក្រៅដើម្បីបិទ (ត្រូវចុចប៊ូតុង Cancel)
      data: {
        qrImage: qrImageBase64,
        totalAmount: this.cartService.cart()?.totalPrice || 0
      }
    });

    // រង់ចាំលទ្ធផលបន្ទាប់ពី Dialog បិទ
    dialogRef.afterClosed().subscribe(result => {
      if (result === 'success') {
        console.log('User claims they paid. Verifying...');
        // ប្តូរទំព័រទៅ /checkout/success ឬ ឆែក API
      } else {
        console.log('Payment cancelled by user.');
      }
    });
  }

}
