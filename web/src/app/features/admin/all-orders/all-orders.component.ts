import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { RouterLink } from '@angular/router';
import { AdminService } from '../../../core/services/admin.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { Order } from '../../../shared/models/order';
import { OrderParams } from '../../../shared/models/orderParams';
import { Pagination } from '../../../shared/models/pagination';
import { AdminSearchComponent } from '../shared/admin-search/admin-search.component';

@Component({
  selector: 'app-all-orders',
  standalone: true,
  imports: [CommonModule, FormsModule, MatPaginatorModule, RouterLink, AdminSearchComponent],
  templateUrl: './all-orders.component.html',
  styleUrl: './all-orders.component.scss',
})
export class AllOrdersComponent implements OnInit {
  adminService = inject(AdminService);
  snack = inject(SnackbarService);

  orders: Order[] = [];
  orderParams = new OrderParams();
  totalItems = 0;

  statusOptions = [
    { value: '', label: 'All statuses' },
    { value: 'Pending', label: 'Pending' },
    { value: 'PaymentReceived', label: 'Payment Received' },
    { value: 'OrderConfirm', label: 'Order Confirm' },
    { value: 'Shipped', label: 'Shipped' },
    { value: 'Delivered', label: 'Delivered' },
    { value: 'ReceivedOrder', label: 'Received Order' },
    { value: 'Cancelled', label: 'Cancelled' },
    { value: 'PaymentFailed', label: 'Payment Failed' },
    { value: 'Refunded', label: 'Refunded' }
  ];

  sourceOptions = [
    { value: '', label: 'All sources' },
    { value: 'Web', label: 'Web' },
    { value: 'POS', label: 'POS' }
  ];

  sortOptions = [
    { value: 'dateDesc', label: 'Newest first' },
    { value: 'dateAsc', label: 'Oldest first' },
    { value: 'totalDesc', label: 'Highest total' },
    { value: 'totalAsc', label: 'Lowest total' }
  ];

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
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

  getStatusBadgeClass(status: string) {
    switch (status) {
      case 'Pending':
        return 'bg-yellow-100 text-yellow-800 dark:bg-yellow-900 dark:text-yellow-300';
      case 'PaymentReceived':
      case 'OrderConfirm':
      case 'ReceivedOrder':
        return 'bg-blue-100 text-blue-800 dark:bg-blue-900 dark:text-blue-300';
      case 'Shipped':
        return 'bg-purple-100 text-purple-800 dark:bg-purple-900 dark:text-purple-300';
      case 'Delivered':
        return 'bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300';
      case 'Cancelled':
      case 'PaymentFailed':
        return 'bg-red-100 text-red-800 dark:bg-red-900 dark:text-red-300';
      case 'Refunded':
        return 'bg-gray-100 text-gray-800 dark:bg-gray-700 dark:text-gray-300';
      default:
        return 'bg-gray-100 text-gray-800 dark:bg-gray-700 dark:text-gray-300';
    }
  }

  getSourceBadgeClass(source: string) {
    return source === 'POS'
      ? 'bg-indigo-100 text-indigo-800 dark:bg-indigo-900 dark:text-indigo-300'
      : 'bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300';
  }
}
