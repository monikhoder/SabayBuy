import { inject, Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { forkJoin, of, tap } from 'rxjs';
import { AccountService } from './account.service';
import { CheckoutService } from './checkout.service';
import { SignalrService } from './signalr.service';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private cartService = inject(CartService);
  private accountService = inject(AccountService);
  private checkoutService = inject(CheckoutService);
  private signalrService = inject(SignalrService);

  init() {
    const id = localStorage.getItem('cart_id');
    const cart$ = id ? this.cartService.getCart(id) : of(null);


    return forkJoin({
      cart: cart$,
      user: this.accountService.getUser().pipe(
        tap(user => {
          if(user) this.signalrService.createHubConnection();
        })
      )
    })
  }
}
