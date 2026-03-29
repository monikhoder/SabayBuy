import { Component, inject, computed } from '@angular/core';
import { AccountService } from '../../../core/services/account.service';
import { Address } from '../../../shared/models/User';
import { CheckoutService } from '../../../core/services/checkout.service';

@Component({
  selector: 'app-address-list',
  imports: [],
  templateUrl: './address-list.component.html',
  styleUrl: './address-list.component.scss',
})
export class AddressListComponent {
  accountService = inject(AccountService);
  checkoutService = inject(CheckoutService);

  // Computed signal for the selected address ID
  selectedAddressId = computed(() => this.accountService.selectedAddress()?.id || '');

  // Method to select an address
  selectAddress(address: Address): void {
    this.accountService.selectedAddress.set(address);
    this.checkoutService.getAvailableShippingMethods(address.zipCode);
  }

  // Method to get the currently selected address
  getSelectedAddress(): Address | null {
    return this.accountService.selectedAddress();
  }

  addNewAddress(): void {
    console.log('Add new address clicked');
  }
}
