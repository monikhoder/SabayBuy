import { Component, inject, OnInit } from '@angular/core';
import { Order } from '../../../shared/models/order';
import { Pagination } from '../../../shared/models/pagination';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { OrderService } from '../../../core/services/order.service';
import { OrderParams } from '../../../shared/models/orderParams';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AdminService } from '../../../core/services/admin.service';
import { OrderCardComponent } from './order-card/order-card.component';
import { AdminSearchComponent } from '../shared/admin-search/admin-search.component';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, FormsModule, MatIconModule, MatPaginatorModule, MatDialogModule, MatButtonModule, MatSelectModule, MatFormFieldModule,  OrderCardComponent, AdminSearchComponent],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss',
})
export class OrdersComponent implements OnInit {
  orderService = inject(OrderService);
  adminService = inject(AdminService);
  snack = inject(SnackbarService);

  orders: Order[] = [];
  orderParams = new OrderParams();
  totalItems = 0;
  statusOptions = ['', 'Pending', 'PaymentReceived', 'Processing', 'OrderConfirm', 'Shipped', 'Delivered', 'Cancelled'];

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    //this.orderParams.search = '8958'; order ID
    this.orderParams.source = 'Web';
    this.adminService.getOrders(this.orderParams).subscribe({
      next: (response: Pagination<Order>) => {
        this.orders = response.data;
        this.totalItems = response.count;
      },
      error: (error) => this.snack.error(error.message)
    });
  }

  onSearch(value: string) {
    this.orderParams.search = value;
    this.orderParams.pageIndex = 1;
    this.getOrders();
  }

  onFilterChange() {
    this.orderParams.pageIndex = 1;
    this.getOrders();
  }

  handlePageEvent(event: any) {
    this.orderParams.pageIndex = event.pageIndex + 1;
    this.orderParams.pageSize = event.pageSize;
    this.getOrders();
  }

  updateOrderStatus(event: {orderId: string, targetStatus: string}) {
    const {orderId, targetStatus} = event;

    if (!targetStatus) {
      this.snack.error('No further actions available for this order status');
      return;
    }

    this.adminService.updateOrderStatus(orderId, targetStatus).subscribe({
      next: (response) => {
        this.snack.success(response);
        this.getOrders(); // Refresh the orders list
      },
      error: (error) => {
        this.snack.error(error.error || 'Failed to update order status');
      }
    });
  }
}
