import { Component, OnInit } from '@angular/core';
import { CartDropdownComponent } from './card/cart-dropdown.component';
import { ProfileDropdownComponent } from './profile/profile-dropdown.component';
import { initFlowbite } from 'flowbite';

@Component({
  selector: 'app-header',
  imports: [CartDropdownComponent, ProfileDropdownComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class Header implements OnInit {
  locations = [
    {
      id: 11,
      Postalcode: '12000',
      name: 'Phnom Penh',
    },
    {
      id: 12,
      Postalcode: '12001',
      name: 'kandal',
    },
    {
      id: 13,
      Postalcode: '12002',
      name: 'Prey Veng',
    },
    {
      id: 14,
      Postalcode: '12003',
      name: 'Prey Veng',
    },
    {
      id: 15,
      Postalcode: '12004',
      name: 'Kampung Thom',
    },
    {
      id: 16,
      Postalcode: '12005',
      name: 'Siem Reap',
    },
    {
      id: 17,
      Postalcode: '12006',
      name: 'Battambang',
    },
    {
      id: 18,
      Postalcode: '12007',
      name: 'Kep',
    },
    {
      id: 19,
      Postalcode: '12009',
      name: 'Svay Rieng',
    },
  ];
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

  ngOnInit(): void {
    initFlowbite();
  }
}
