import { Component, inject, OnInit } from '@angular/core';
import { OrderService } from '../../core/services/order.service';
import { Order } from '../../shared/models/order';
import { RouterLink } from '@angular/router';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { OrderParams } from '../../shared/models/orderParams';
import { FormsModule } from '@angular/forms';
import { MatIcon } from "@angular/material/icon";
import { LoadingService } from '../../core/services/loading.service';

@Component({
  selector: 'app-order',
  imports: [
    RouterLink,
    DatePipe,
    CurrencyPipe,
    FormsModule,
    MatIcon
],
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss',
})
export class OrderComponent implements OnInit {
  private orderService = inject(OrderService);
  loadingService = inject(LoadingService);
  myorders: Order[] = [];
  orderParams = new OrderParams();
  totalCount = 0;

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrdersForUser(this.orderParams).subscribe({
      next: (response) => {
        this.myorders = response.data;
        this.totalCount = response.count;
      },
      error: (error) => {
        console.error('Error fetching orders:', error);
      },
    });
  }
  HandlePaginationChange(pageNumber: number) {
    this.orderParams.pageSize += this.orderParams.defaultPageSize;
    this.getOrders(); // Reload orders with new page number
  }

  onFilterChange() {
    this.orderParams.pageIndex = 1;
    this.getOrders();
  }
}
