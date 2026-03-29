import { Component, inject } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { RouterLink } from '@angular/router';
import { Location } from '@angular/common';
import { CheckoutService } from '../../core/services/checkout.service';

@Component({
  selector: 'app-app-order-summary',
  imports: [RouterLink],
  templateUrl: './app-order-summary.component.html',
  styleUrl: './app-order-summary.component.scss',
})
export class AppOrderSummaryComponent {
  cartService = inject(CartService);
  checkoutService = inject(CheckoutService);
  location = inject(Location);

}
