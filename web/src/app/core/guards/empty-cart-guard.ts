import { CanActivateFn, Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { inject } from '@angular/core';

export const emptyCartGuard: CanActivateFn = (route, state) => {
  const cartService = inject(CartService);
  const router = inject(Router);
  if(!cartService.cart() || cartService.cart()?.items.length === 0){
    return router.createUrlTree(['/cart']);
  }
  return true;
};
