import { Component, inject, OnInit, signal } from '@angular/core';
import { initFlowbite } from 'flowbite';
import { ShopServices } from '../../core/services/shop.service';
import { Category } from '../../shared/models/category';
import { Product } from '../../shared/models/product';
import { productParams } from '../../shared/models/productParams';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ProductCardComponent } from '../Shopping/product-list/product-card/product-card.component';
import { categoryParams } from '../../shared/models/categoryParams';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatButtonModule,
    MatIconModule,
    ProductCardComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {

  Categories = signal<Category[]>([]);
  featuredProducts = signal<Product[]>([]);
  private shopServices = inject(ShopServices);
  categoryParams = new categoryParams;

  ngOnInit(): void {
    initFlowbite();
    this.categoryParams.isParent = true;
    this.shopServices.getCategories(this.categoryParams).subscribe({
      next: (response) => {
        this.Categories.set(response.data);
      }
    });

    const params: productParams = {
      brand: [],
      category: [],
      search: '',
      sort: 'name',
      pageIndex: 1,
      pageSize: 4,
      isActive: true,
      defaultPageSize: 4
    };

    this.shopServices.getProducts(params).subscribe({
      next: (response) => {
        this.featuredProducts.set(response.data);
      }
    });
  }

}
