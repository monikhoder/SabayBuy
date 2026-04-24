import { Component, inject, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-cart-dropdown',
  imports: [RouterLink],
  templateUrl: './cart-dropdown.component.html',
  styleUrl: './cart-dropdown.component.scss',
})
export class CartDropdownComponent {
  @Input() open = false;

  cartService = inject(CartService);

  removeItem(productId: string, variantId: string) {
    this.cartService.removeItemFromCart(productId, variantId).subscribe();
  }
}
