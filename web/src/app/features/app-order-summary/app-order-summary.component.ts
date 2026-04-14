import { Component, inject, signal } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { Router, RouterLink } from '@angular/router';
import { Location } from '@angular/common';
import { CheckoutService } from '../../core/services/checkout.service';
import { MatDialog } from '@angular/material/dialog';
import { AbaQrDialogComponent } from '../checkout/aba-qr-dialog/aba-qr-dialog.component';
import { OrderService } from '../../core/services/order.service';
import { CreateOrder, Order } from '../../shared/models/order';
import { AccountService } from '../../core/services/account.service';

@Component({
  selector: 'app-app-order-summary',
  imports: [RouterLink],
  templateUrl: './app-order-summary.component.html',
  styleUrl: './app-order-summary.component.scss',
})
export class AppOrderSummaryComponent {
  cartService = inject(CartService);
  checkoutService = inject(CheckoutService);
  orderService = inject(OrderService);
  accountService = inject(AccountService);
  location = inject(Location);
  dialog = inject(MatDialog);
  router = inject(Router);

  qrCodeImage = signal<string | null>(null);
  isProcessing = signal<boolean>(false);



  onCheckoutSubmit() {
    this.isProcessing.set(true);
    this.checkoutService.createPaymentIntent().subscribe({
      next: (payment_response: any) => {
        const orderDto = this.createOrderDto(payment_response.status.tran_id || '');
        this.orderService.createOrder(orderDto).subscribe({
          next: (order) => {
            this.isProcessing.set(false);
            if (this.checkoutService.selectedPaymentMethod() === 'aba' && payment_response.qrImage) {
              this.openAbaQrDialog(payment_response.qrImage, order.total.toString(), payment_response.status.tran_id);
            } else {
              this.router.navigate(['/checkout/success'], { state: { orderId: order.id } });
            }
          },
          error: (error) => {
            this.isProcessing.set(false);
            console.error('Error creating order', error);
          },
          complete: () => {
            this.cartService.deleteCart(this.cartService.cart()?.id || '');
            this.cartService.cart.set(null);
            this.orderService.orderComplete = true;
          }
        });
      },
      error: (error) => {
        this.isProcessing.set(false);
        console.error('Error during checkout', error);
      }
    });
  }
  openAbaQrDialog(qrImageBase64: string, totalAmount: string, tran_id:string) {
    const dialogRef = this.dialog.open(AbaQrDialogComponent, {
      width: '400px',
      disableClose: true,
      data: {
        qrImage: qrImageBase64,
        totalAmount: totalAmount,
        tran_id: tran_id
      }
    });


    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
      } else {
        console.log('Payment cancelled by user.');
      }
    });
  }
  private createOrderDto(paymentIntentId?: string): CreateOrder {
    const createOrderDto: CreateOrder = {
      cartId: this.cartService.cart()!.id,
      deliveryMethodId: this.checkoutService.selectedShippingMethod()?.id || '',
      shippingAddress: {
          fullName: this.checkoutService.accountService.selectedAddress()?.fullName || '',
          line1: this.checkoutService.accountService.selectedAddress()?.line1 || '',
          line2: this.checkoutService.accountService.selectedAddress()?.line2 || '',
          phoneNumber: this.checkoutService.accountService.selectedAddress()?.phoneNumber || '',
          city: this.checkoutService.accountService.selectedAddress()?.city || '',
          state: this.checkoutService.accountService.selectedAddress()?.state || '',
          zipCode: this.checkoutService.accountService.selectedAddress()?.zipCode || '',
          country: this.checkoutService.accountService.selectedAddress()?.country || '',
          latitude: this.checkoutService.accountService.selectedAddress()?.latitude || 0,
          longitude: this.checkoutService.accountService.selectedAddress()?.longitude || 0,
      },
      paymentMethod: this.checkoutService.selectedPaymentMethod() === 'aba' ? 0 : 1,
      paymentIntentId: paymentIntentId || '',
    };
    return createOrderDto;
  }

}
