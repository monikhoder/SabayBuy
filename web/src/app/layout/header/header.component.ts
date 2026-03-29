import { Component, inject, OnInit, signal } from '@angular/core';
import { CartDropdownComponent } from './card/cart-dropdown.component';
import { ProfileDropdownComponent } from './profile/profile-dropdown.component';
import { LoadingService } from '../../core/services/loading.service';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { CartService } from '../../core/services/cart.service';
import { AccountService } from '../../core/services/account.service';
import { Address } from '../../shared/models/User';

@Component({
  selector: 'app-header',
  imports: [CartDropdownComponent, ProfileDropdownComponent, MatProgressBarModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class Header implements OnInit {
  loadingService = inject(LoadingService)
  cartService = inject(CartService)
  accountService = inject(AccountService)
  isLogin = signal(false);
  selectedAddress = signal<Address | null>(null);



  Langueges = [
    {
      id: 1,
      flag: 'USA-flag.png',
      name: 'English (USA)',
    },
    {
      id: 2,
      flag: 'cambodia-flag.png',
      name: 'ខ្មែរ (Cambodia)',
    },
  ];
  searchType =[
    {
      name : 'Products Name',
      value : 'product'
    },
    {
      name : 'Category Name',
      value : 'category'
    },
    {
      name : 'Brand Name',
      value : 'brand'
    }
  ]
  selectedSearchType = this.searchType[0];


  Islog(){
   if(this.accountService.currentUser()){
     this.isLogin.set(true);
   }
  }
  selectAdress(address: Address) {

    this.selectedAddress.set(address);
  }
  loadAddress(){
    if(this.selectedAddress() == null){
      const defaultAddress = this.accountService.currentUser()?.addresses.find(a => a.isDefault);
      this.selectedAddress.set(defaultAddress || null);
    }
  }

  ngOnInit(): void {
    this.Islog();
    this.loadAddress();
  }
}
