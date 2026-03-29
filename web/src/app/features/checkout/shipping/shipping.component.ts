import { Component, inject, computed } from '@angular/core';
import { AccountService } from '../../../core/services/account.service';
import { CheckoutService } from '../../../core/services/checkout.service';
import { DeliveryMethod } from '../../../shared/models/deliveryMethod';

@Component({
  selector: 'app-shipping',
  imports: [],
  templateUrl: './shipping.component.html',
  styleUrl: './shipping.component.scss',
})
export class ShippingComponent {
  accountService = inject(AccountService);
  checkoutService = inject(CheckoutService);

  // Computed signal for the selected shipping method ID
  selectedShippingMethodId = computed(
    () => this.checkoutService.selectedShippingMethod()?.id || '',
  );

  // Method to select a shipping method
  selectShippingMethod(method: DeliveryMethod): void {
    this.checkoutService.selectedShippingMethod.set(method);
  }

  // Method to get the currently selected shipping method
  getSelectedShippingMethod(): DeliveryMethod | null {
    return this.checkoutService.selectedShippingMethod();
  }
}
