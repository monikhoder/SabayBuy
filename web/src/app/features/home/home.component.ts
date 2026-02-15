import { Component, inject, OnInit, signal } from '@angular/core';
import { initFlowbite } from 'flowbite';
import { ShopServices } from '../../core/services/shop.services';
import { Category } from '../../shared/models/category';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {

  Categories = signal<Category[]>([]);
  private shopServices = inject(ShopServices);

  ngOnInit(): void {
    initFlowbite();

   this.shopServices.getCategories().subscribe({
      next: (response) => {
        this.Categories.set(response.data);
      }
    });
  }

}
