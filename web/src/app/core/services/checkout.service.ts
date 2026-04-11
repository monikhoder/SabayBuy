import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit, signal, Signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { DeliveryMethod } from '../../shared/models/deliveryMethod';
import { PaymentMethod } from '../../shared/models/paymentMethod';
import { CartService } from './cart.service';
import { CheckOut } from '../../shared/models/checkout';
import { CreateOrder } from '../../shared/models/order';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
export class CheckoutService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  cartService = inject(CartService);
  accountService = inject(AccountService);
  AvailableShippingMethods = signal<DeliveryMethod[]>([]);
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

  createPaymentIntent() {
    const checkoutDto: CheckOut = {
      cartId: this.cartService.cart()!.id,
      paymentMethod: this.selectedPaymentMethod(),
      deliveryMethodId: this.selectedShippingMethod()?.id || '',
      shippingAddressId: this.selectedShippingMethod()?.id || '',
    };
    return this.http.post(this.baseUrl + 'Payments/checkout', checkoutDto)
  }

  getAvailableShippingMethods(zip: string) {
    return this.http
      .get(this.baseUrl + 'Payments/delivery-methods/' + zip)
      .subscribe((methods: any) => {
        this.AvailableShippingMethods.set(methods);
        this.selectedShippingMethod.set(methods.length > 0 ? methods[0] : null);
      });
  }

   
}
