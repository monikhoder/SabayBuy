import { Component, inject, OnInit, signal } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { RouterLink } from '@angular/router';
import { AppOrderSummaryComponent } from "../app-order-summary/app-order-summary.component";
import { MatStepperModule } from '@angular/material/stepper';
import { AddressComponent } from "./address/address.component";
import { AccountService } from '../../core/services/account.service';
import { ShippingComponent } from "./shipping/shipping.component";
import { CheckoutService } from '../../core/services/checkout.service';
import { Address } from '../../shared/models/User';
import { AddressListComponent } from "./address-list/address-list.component";
import { PaymentMethodComponent } from "./payment-method/payment-method.component";
import { OrderReviewComponent } from "./order-review/order-review.component";

@Component({
  selector: 'app-checkout',
  imports: [ AppOrderSummaryComponent, MatStepperModule, AddressComponent, ShippingComponent, AddressListComponent, PaymentMethodComponent, OrderReviewComponent],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss',
})
export class CheckoutComponent implements OnInit {
  cartService = inject(CartService);
  accountService = inject(AccountService);
  checkoutService = inject(CheckoutService)




  ngOnInit(): void {
  this.checkoutService.getAvailableShippingMethods(this.accountService.selectedAddress()?.zipCode || '');
  }

  selectAdderess(address: Address){
    if(address){
      this.accountService.selectedAddress.set(address);
    }

  }

}
