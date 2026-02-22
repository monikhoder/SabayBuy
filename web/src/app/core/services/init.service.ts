import { inject, Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private cartService = inject(CartService);
  
  init() {
    const id = localStorage.getItem('cart_id');
    const cart$ = id ? this.cartService.getCart(id) : of(null);
    return cart$;
  }
}
