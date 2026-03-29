import { inject, Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { forkJoin, of } from 'rxjs';
import { AccountService } from './account.service';
import { CheckoutService } from './checkout.service';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private cartService = inject(CartService);
  private accountService = inject(AccountService);
  private checkoutService = inject(CheckoutService);

  init() {
    const id = localStorage.getItem('cart_id');
    const cart$ = id ? this.cartService.getCart(id) : of(null);


    return forkJoin({
      cart: cart$,
      user: this.accountService.getUser()
    })
  }
}
