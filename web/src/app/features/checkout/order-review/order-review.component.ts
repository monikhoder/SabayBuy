import { Component, computed, inject } from '@angular/core';
import { CartService } from '../../../core/services/cart.service';
import { CheckoutService } from '../../../core/services/checkout.service';
import { AccountService } from '../../../core/services/account.service';
import { CurrencyPipe } from '@angular/common';
import { MatStepperModule } from '@angular/material/stepper';

@Component({
  selector: 'app-order-review',
  imports: [CurrencyPipe, MatStepperModule],
  templateUrl: './order-review.component.html',
  styleUrl: './order-review.component.scss',
})
export class OrderReviewComponent {
  cartService = inject(CartService);
  checkoutService = inject(CheckoutService);
  accountService = inject(AccountService);

  paymentMethod = computed(() => {
    const paymentId = this.checkoutService.selectedPaymentMethod();
    return this.checkoutService.paymentMethods().find(p => p.id === paymentId);
  });
}
