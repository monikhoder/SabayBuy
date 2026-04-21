import { Component, computed, inject } from '@angular/core';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { AccountService } from '../../core/services/account.service';
import { CartService } from '../../core/services/cart.service';
import { LoadingService } from '../../core/services/loading.service';
import { CartDropdownComponent } from './card/cart-dropdown.component';
import { ProfileDropdownComponent } from './profile/profile-dropdown.component';

@Component({
  selector: 'app-header',
  imports: [CartDropdownComponent, ProfileDropdownComponent, MatProgressBarModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class Header {
  loadingService = inject(LoadingService);
  cartService = inject(CartService);
  accountService = inject(AccountService);

  isLoggedIn = computed(() => !!this.accountService.currentUser());
  selectedAddress = computed(() => {
    const user = this.accountService.currentUser();
    return this.accountService.selectedAddress() ?? user?.addresses.find((address) => address.isDefault) ?? null;
  });

  Langueges = [
    {
      id: 1,
      flag: 'USA-flag.png',
      name: 'English (USA)',
    },
    {
      id: 2,
      flag: 'cambodia-flag.png',
      name: 'Khmer (Cambodia)',
    },
  ];

  searchType = [
    {
      name: 'Products Name',
      value: 'product',
    },
    {
      name: 'Category Name',
      value: 'category',
    },
    {
      name: 'Brand Name',
      value: 'brand',
    },
  ];

  selectedSearchType = this.searchType[0];
}
