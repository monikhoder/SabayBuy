import { Component, inject, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartService } from '../../../../core/services/cart.service';
import { Product } from '../../../../shared/models/product';

@Component({
  selector: 'app-product-card',
  imports: [
    RouterLink
  ],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss',
})
export class ProductCardComponent {
  @Input() product?: Product;

  cartService = inject(CartService);

  addToCart() {
    if (!this.product?.variants.length) return;

    this.cartService.addItemToCart(this.product, this.product.variants[0].id).subscribe();
  }
}
