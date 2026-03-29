import { NgClass } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { CheckoutService } from '../../../core/services/checkout.service';

export interface PaymentMethod {
  id: string;
  name: string;
  description: string;
  icon: string;
  isAvailable: boolean;
}

@Component({
  selector: 'app-payment-method',
  imports: [NgClass],
  templateUrl: './payment-method.component.html',
  styleUrl: './payment-method.component.scss',
})
export class PaymentMethodComponent {
  checkoutService = inject(CheckoutService);


  // Method to select a payment method
  selectPaymentMethod(methodId: string): void {
    const method = this.checkoutService.paymentMethods().find(m => m.id === methodId);
    if (!method || !method.isAvailable) {
      return;
    }
    this.checkoutService.selectedPaymentMethod.set(methodId);
  }
}
