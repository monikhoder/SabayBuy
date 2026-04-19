import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Order, CreateOrder} from '../../shared/models/order';
import { Pagination } from '../../shared/models/pagination';
import { OrderParams } from '../../shared/models/orderParams';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  orderComplete = false;

  createOrder(order: CreateOrder) {
    return this.http.post<Order>(this.baseUrl + 'orders', order);
  }

  getOrdersForUser(orderParams: OrderParams) {
    let params = new HttpParams();

    if (orderParams.status && orderParams.status !== '') {
      params = params.append('status', orderParams.status);
    }
    if (orderParams.search && orderParams.search !== '') {
      params = params.append('search', orderParams.search);
    }
    params = params.append('pageIndex', orderParams.pageIndex);
    params = params.append('pageSize', orderParams.pageSize);

    return this.http.get<Pagination<Order>>(this.baseUrl + 'orders', { params });
  }
  

  getOrderById(id: string) {
    return this.http.get<Order>(this.baseUrl + 'orders/' + id);
  }

}
