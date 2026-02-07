import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Category } from '../../shared/models/category';
import { Product } from '../../shared/models/product';

@Injectable({
  providedIn: 'root',
})
export class ShopServices {
  baseUrl = 'http://localhost:5110/api/';
  private http = inject(HttpClient);

  getCategories() {
    return this.http.get<Pagination<Category>>(this.baseUrl + 'Categories?isParent=true')
  }
  getProducts() {
    return this.http.get<Pagination<Product>>(this.baseUrl + 'Products')
  }
  getBrands(){
    return this.http.get<string[]>(this.baseUrl + 'brand')
  }

}
