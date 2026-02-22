import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { initFlowbite } from 'flowbite';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-cart-dropdown',
  imports: [RouterLink],
  templateUrl: './cart-dropdown.component.html',
  styleUrl: './cart-dropdown.component.scss',
})
export class CartDropdownComponent implements OnInit {

  cartService = inject(CartService);

  ngOnInit(): void {
    initFlowbite();
  }
}
