import { Component, computed, HostListener, inject, signal } from '@angular/core';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { Router } from '@angular/router';
import { AccountService } from '../../core/services/account.service';
import { CartService } from '../../core/services/cart.service';
import { LoadingService } from '../../core/services/loading.service';
import { CartDropdownComponent } from './card/cart-dropdown.component';
import { ProfileDropdownComponent } from './profile/profile-dropdown.component';
import { Address } from '../../shared/models/User';

type HeaderDropdown = 'language' | 'location' | 'categories' | 'cart' | 'account' | null;

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
  router = inject(Router);

  openDropdown = signal<HeaderDropdown>(null);
  isMobileSearchOpen = signal(false);
  isSearchFocused = signal(false);
  desktopSearchTerm = signal('');
  mobileSearchTerm = signal('');

  isLoggedIn = computed(() => !!this.accountService.currentUser());
  selectedAddress = computed(() => {
    const user = this.accountService.currentUser();
    return this.accountService.selectedAddress() ?? user?.addresses.find((address) => address.isDefault) ?? null;
  });

  languages = [
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

  searchTypes = [
    {
      name: 'Products',
      value: 'product',
    },
    {
      name: 'Categories',
      value: 'category',
    },
    {
      name: 'Brands',
      value: 'brand',
    },
  ];

  selectedSearchType = signal(this.searchTypes[0]);

  @HostListener('document:click')
  handleDocumentClick() {
    this.closeAllMenus();
  }

  toggleDropdown(dropdown: Exclude<HeaderDropdown, null>, event: Event) {
    event.stopPropagation();
    this.openDropdown.update((current) => (current === dropdown ? null : dropdown));
  }

  toggleMobileSearch(event: Event) {
    event.stopPropagation();
    this.isMobileSearchOpen.update((value) => !value);
    this.openDropdown.set(null);
  }

  closeAllMenus() {
    this.openDropdown.set(null);
    this.isMobileSearchOpen.set(false);
  }

  keepMenuOpen(event: Event) {
    event.stopPropagation();
  }

  selectAddress(address: Address) {
    this.accountService.selectedAddress.set(address);
    this.closeAllMenus();
  }

  selectSearchType(type: { name: string; value: string }) {
    this.selectedSearchType.set(type);
    this.openDropdown.set(null);
  }

  submitSearch(event: Event, source: 'desktop' | 'mobile') {
    event.preventDefault();

    const rawTerm = source === 'desktop' ? this.desktopSearchTerm() : this.mobileSearchTerm();
    const searchTerm = rawTerm.trim();

    this.router.navigate(['/products'], {
      queryParams: {
        q: searchTerm || null,
        type: searchTerm ? this.selectedSearchType().value : null,
      },
    });

    this.closeAllMenus();
  }
}
