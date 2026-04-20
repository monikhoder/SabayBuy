import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Pagination } from '../../shared/models/pagination';
import { AddCategory, Category } from '../../shared/models/category';
import { categoryParams } from '../../shared/models/categoryParams';
import { createproductDto, CreateProductVariantDto, CreateVariantAttributeDto, Product } from '../../shared/models/product';
import { OrderParams } from '../../shared/models/orderParams';
import { Order } from '../../shared/models/order';


@Injectable({
  providedIn: 'root',
})
export class AdminService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);


  //Category
  addCategory(category: AddCategory){
    return this.http.post<Category>(this.baseUrl + 'categories', category)
  }
  updateCategory(id: string, category: AddCategory) {
    return this.http.put<Category>(this.baseUrl + 'categories/' + id, category );
  }
  deleteCategory(id: string) {
    return this.http.delete(this.baseUrl + 'categories/' + id, { responseType: 'text' });
  }
  //Product
  addProduct(product : createproductDto){
    return this.http.post<Product>(this.baseUrl + 'products', product)
  }
  updateProduct(id: string, product: any) {
    return this.http.put<Product>(this.baseUrl + 'products/' + id, product);
  }
  addProductVariant(variant: CreateProductVariantDto, productId: string) {
    return this.http.post<any>(this.baseUrl + 'products/' + productId + '/variants', variant);
  }
  updateVariant(id: string, variant: CreateProductVariantDto) {
    return this.http.put<any>(this.baseUrl + 'variants/' + id, variant);
  }
  addVariantAttribute(attribute: CreateVariantAttributeDto, varientId: string) {
    return this.http.post<any>(this.baseUrl + 'variants/' + varientId + '/attributes', attribute);
  }
  deleteProduct(id: string) {
    return this.http.delete(this.baseUrl + 'products/' + id, { responseType: 'text' });
  }
  deleteVariant(id: string) {
    return this.http.delete(this.baseUrl + 'variants/' + id, { responseType: 'text' });
  }
  deleteAttribute(id:string){
    return this.http.delete(this.baseUrl + 'attribute/' + id, { responseType: 'text' });
  }

  //Get all Order
   getOrders(orderParams: OrderParams) {
      let params = new HttpParams();

      if (orderParams.status && orderParams.status !== '') {
        params = params.append('status', orderParams.status);
      }
      if (orderParams.search && orderParams.search !== '') {
        params = params.append('search', orderParams.search);
      }
      params = params.append('pageIndex', orderParams.pageIndex);
      params = params.append('pageSize', orderParams.pageSize);

      return this.http.get<Pagination<Order>>(this.baseUrl + 'adminOrder', { params });
    }

  //get order by ID
  getOrderById(id: string) {
    return this.http.get<Order>(this.baseUrl + 'adminOrder/' + id);
  }

  //update order status
  updateOrderStatus(id: string, status: string) {
    return this.http.put(this.baseUrl + 'adminOrder/' + id + '?orderstatus=' + status, {}, { responseType: 'text' });
  }
  //Update product status togle
  updateProductStatus(id:string){
    return this.http.put(this.baseUrl + 'Products/status/' + id , {}, { responseType: 'text' });
  }
}
