import { Component, inject, computed, Output, EventEmitter } from '@angular/core';
import { AccountService } from '../../../core/services/account.service';
import { Address } from '../../../shared/models/User';
import { CheckoutService } from '../../../core/services/checkout.service';
import { SnackbarService } from '../../../core/services/snackbar.service';

@Component({
  selector: 'app-address-list',
  imports: [],
  templateUrl: './address-list.component.html',
  styleUrl: './address-list.component.scss',
})
export class AddressListComponent {
  accountService = inject(AccountService);
  checkoutService = inject(CheckoutService);
  snack = inject(SnackbarService);

  @Output() editAddress = new EventEmitter<Address>();
  @Output() addAddress = new EventEmitter<void>();

  // Computed signal for the selected address ID
  selectedAddressId = computed(() => this.accountService.selectedAddress()?.id || '');

  // Method to select an address
  selectAddress(address: Address): void {
    this.accountService.selectedAddress.set(address);
    this.checkoutService.getAvailableShippingMethods(address.zipCode).subscribe();
  }

  // Method to get the currently selected address
  getSelectedAddress(): Address | null {
    return this.accountService.selectedAddress();
  }

  addNewAddress(): void {
    this.addAddress.emit();
  }

  onEditAddress(address: Address): void {
    this.editAddress.emit(address);
  }

  onDeleteAddress(address: Address): void {
    if (address.id) {
      if (confirm('Are you sure you want to delete this address?')) {
        this.accountService.deleteAddress(address.id).subscribe({
          next: () => {
            this.accountService.getUser().subscribe();
            this.snack.success('Address deleted successfully');
          },
          error: (err) => {
            this.snack.error(err.error || 'Failed to delete address');
          }
        });
      }
    }
  }
}
