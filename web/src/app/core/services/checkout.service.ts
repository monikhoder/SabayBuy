import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { DeliveryMethod } from '../../shared/models/deliveryMethod';
import { PaymentMethod } from '../../shared/models/paymentMethod';
import { CartService } from './cart.service';
import { AccountService } from './account.service';
import { tap } from 'rxjs';
import { AbaCheckoutResponse, CreateOrder, Order } from '../../shared/models/order';

@Injectable({
  providedIn: 'root',
})
export class CheckoutService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  cartService = inject(CartService);
  accountService = inject(AccountService);
  availableShippingMethods = signal<DeliveryMethod[]>([]);
  selectedShippingMethod = signal<DeliveryMethod | null>(null);
  selectedPaymentMethod = signal<string>('aba');

  // Available payment methods
  paymentMethods = signal<PaymentMethod[]>([
    {
      id: 'aba',
      name: 'ABA PayWay',
      description: 'Pay with ABA Bank payment gateway',
      icon: 'https://cdn.brandfetch.io/iduTsrn35q/w/800/h/800/theme/dark/icon.jpeg?c=1bxid64Mup7aczewSAYMX&t=1772298467631',
      isAvailable: true,
    },
    {
      id: 'stripe',
      name: 'Stripe',
      description: 'Pay with Stripe payment gateway',
      icon: 'https://cdn.brandfetch.io/idxAg10C0L/theme/dark/logo.svg?c=1bxid64Mup7aczewSAYMX&t=1746435914582',
      isAvailable: false,
    },
    {
      id: 'cod',
      name: 'Cash on Delivery',
      description: 'Pay in cash when your order arrives',
      icon: 'https://png.pngtree.com/png-clipart/20210606/original/pngtree-cash-on-delivery-cod-fast-car-with-flat-design-style-orange-png-image_6393505.jpg',
      isAvailable: true,
    },
  ]);

  checkoutV2(order: CreateOrder) {
    return this.http.post<Order | AbaCheckoutResponse>(this.baseUrl + 'Payments/checkout-v2', order);
  }

  getAvailableShippingMethods(zip: string) {
    return this.http
      .get<DeliveryMethod[]>(this.baseUrl + 'Payments/delivery-methods/' + zip)
      .pipe(
        tap((methods) => {
          this.availableShippingMethods.set(methods);
          this.selectedShippingMethod.set(methods.length > 0 ? methods[0] : null);
        })
      );
  }

   
}
