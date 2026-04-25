import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductCardComponent } from "./product-card/product-card.component";
import { FilterComponent } from "./filter/filter.component";
import { SortComponent } from "./sort/sort.component";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { ShopServices } from '../../../core/services/shop.service';
import { LoadingService } from '../../../core/services/loading.service';
import { Category } from '../../../shared/models/category';
import { Product } from '../../../shared/models/product';
import { productParams } from '../../../shared/models/productParams';
import { categoryParams } from '../../../shared/models/categoryParams';
import { BrandGroup } from './filter/filter.component';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    CommonModule,
    ProductCardComponent,
    FilterComponent,
    SortComponent,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    RouterLink,
    MatProgressSpinnerModule
  ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent implements OnInit {
  private shopService = inject(ShopServices);
  private activatedRoute = inject(ActivatedRoute);
  loadingService = inject(LoadingService)
  brands: string[] = [];
  groupedBrands: BrandGroup[] = []
  categories: Category[] = [];
  products: Product[] = [];
  productParams = new productParams();
  categoryParams = new categoryParams();
  count: number = 0;


  ngOnInit(): void {
    this.loadcategories();
    this.loadBrands();
    this.activatedRoute.queryParamMap.subscribe(params => {
      this.applyQueryParams(params.get('q') ?? '', params.get('type') ?? 'product');
      this.loadProducts();
    });
  }

  private applyQueryParams(query: string, type: string) {
    this.productParams = new productParams();
    this.productParams.isActive = true;

    const trimmedQuery = query.trim();
    if (!trimmedQuery) {
      return;
    }

    if (type === 'category') {
      this.productParams.category = [trimmedQuery];
      return;
    }

    if (type === 'brand') {
      this.productParams.brand = [trimmedQuery];
      return;
    }

    this.productParams.search = trimmedQuery;
  }

  loadcategories() {
    this.categoryParams.isParent = true;
    this.shopService.getCategories(this.categoryParams).subscribe({
      next: response => {
        this.categories = response.data
          .map(category => ({
            ...category,
            subCategories: category.subCategories.filter(subcategory => subcategory.productCount > 0)
          }))
          .filter(category => category.productCount > 0 || category.subCategories.length > 0);
      }
    })
  }
  loadProducts() {
    this.productParams.isActive = true;
    this.shopService.getProducts(this.productParams).subscribe({
      next: response => {
        this.products = response.data;
        this.count = response.count;
      },
      error: error => console.log(error)
    })
  }
  loadBrands() {
    this.shopService.getBrands().subscribe({
      next: (response) => {
        this.brands = response;
        this.groupBrands();
      },
      error: (error) => console.log(error)
    });
  }

  groupBrands() {
    const groups: { [key: string]: string[] } = {};

    this.brands.forEach(brand => {
      const firstLetter = brand.charAt(0).toUpperCase();

      if (!groups[firstLetter]) {
        groups[firstLetter] = [];
      }
      groups[firstLetter].push(brand);
    });
    this.groupedBrands = Object.keys(groups)
      .sort()
      .map(letter => ({
        letter: letter,
        brands: groups[letter]
      }));
  }
  // 1. Receive the list of brands from FilterComponent
  handleBrandFilter(brands: string[]) {
    this.productParams.brand = brands;
    this.loadProducts(); // Reload products with new filter
  }

  // 2. Receive the list of categories from FilterComponent
  handleCategoryFilter(categories: string[]) {
    this.productParams.category = categories;
    this.loadProducts(); // Reload products with new filter
  }

  HandleSortChange(sortValue: string) {
    this.productParams.sort = sortValue;
    this.loadProducts(); // Reload products with new sort
  }
  HandlePaginationChange(pageNumber: number) {
    this.productParams.pageSize += this.productParams.defaultPageSize;
    this.loadProducts(); // Reload products with new page number
  }
  removeBrandFilter(brand: string) {
    this.productParams.brand = this.productParams.brand.filter(b => b !== brand);
    this.loadProducts();
  }
  removeCategoryFilter(category: string) {
    this.productParams.category = this.productParams.category.filter(c => c !== category);
    this.loadProducts();
  }

  resetAllFilters() {
    this.productParams.brand = [];
    this.productParams.category = [];
    this.productParams.pageIndex = 1;
    this.loadProducts();
  }

}
