import { Component, inject, OnInit, signal } from '@angular/core';
import { ShopServices } from '../../core/services/shop.services';
import { Category } from '../../shared/models/category';
import { Product } from '../../shared/models/product';
import { ProductCardComponent } from "./product-card/product-card.component";
import { FilterComponent } from "./filter/filter.component";
import { SortComponent } from "./sort/sort.component";
import { productParams } from '../../shared/models/productParams';

@Component({
  selector: 'app-product-list',
  imports: [ProductCardComponent, FilterComponent, SortComponent],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent implements OnInit {
  private shopService = inject(ShopServices);
  brands: string[] = [];
  groupedBrands: BrandGroup[] = []
  categories: Category[] = [];
  products: Product[] = [];
  productParams = new productParams();
  count: number = 0;


  ngOnInit(): void {
    this.loadcategories();
    this.loadProducts();
    this.loadBrands();
  }

  loadcategories(){
    this.shopService.getCategories().subscribe({
      next: response => {
        this.categories = response.data;
      }
    })
  }
    loadProducts(){
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


}
