import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-shopping-cart',
  imports: [RouterLink],
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.scss',
})
export class ShoppingCartComponent {
  cartService = inject(CartService);

  updateQuantity(productId: string, variantId: string, increase: number, quantity?: string) {
    const item = this.cartService.cart()?.items.find(
      (cartItem) => cartItem.productId === productId && cartItem.productVariantId === variantId
    );

    if (!item) return;

    this.cartService.addItemToCart(item, variantId, increase, quantity).subscribe();
  }

  removeItem(productId: string, variantId: string) {
    this.cartService.removeItemFromCart(productId, variantId).subscribe();
  }
}
