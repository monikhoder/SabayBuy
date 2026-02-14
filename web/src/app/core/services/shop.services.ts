import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Pagination } from '../../shared/models/pagination';
import { Category } from '../../shared/models/category';
import { Product } from '../../shared/models/product';
import { productParams } from '../../shared/models/productParams';

@Injectable({
  providedIn: 'root',
})
export class ShopServices {
  baseUrl = 'http://localhost:5110/api/';
  private http = inject(HttpClient);



  getCategories() {
    return this.http.get<Pagination<Category>>(this.baseUrl + 'Categories?isParent=true')
  }
  getProducts(productParams: productParams) {
    let params = new HttpParams();

    if (productParams.brand && productParams.brand.length > 0) {
      params = params.append('brands', productParams.brand.join(','));
    }
    if (productParams.category && productParams.category.length > 0) {
      params = params.append('categories', productParams.category.join(','));
    }
    if (productParams.search) {
      params = params.append('search', productParams.search);
    }
    params = params.append('sort', productParams.sort);
    params = params.append('pageIndex', productParams.pageIndex);
    params = params.append('pageSize', productParams.pageSize);
    return this.http.get<Pagination<Product>>(this.baseUrl + 'Products', { params })
  }
  getProduct(id: string) {
    return this.http.get<Product>(this.baseUrl + 'Products/' + id)
  }
  getBrands(){
    return this.http.get<string[]>(this.baseUrl + 'brand')
  }

}
