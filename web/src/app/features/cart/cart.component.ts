import { Component, inject } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { RouterLink } from "@angular/router";
import { AppOrderSummaryComponent } from "../app-order-summary/app-order-summary.component";
import { ShoppingCartComponent } from "./shopping-cart/shopping-cart.component";

@Component({
  selector: 'app-cart',
  imports: [ AppOrderSummaryComponent, ShoppingCartComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss',
})
export class CartComponent {
  cartService = inject(CartService);
}
