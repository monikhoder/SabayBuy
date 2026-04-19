import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Order } from '../../../../shared/models/order';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-order-card',
  imports: [CommonModule, RouterLink, MatButtonModule],
  templateUrl: './order-card.component.html',
  styleUrl: './order-card.component.scss',
})
export class OrderCardComponent {
  @Input() order!: Order;
  @Output() statusUpdate = new EventEmitter<{ orderId: string, currentStatus: string, paymentMethod?: string }>();

  getStatusBadgeClass(status: string): string {
    switch (status.toLowerCase()) {
      case 'pending':
        return 'bg-yellow-100 text-sm px-1 rounded-md';
      case 'paymentreceived':
        return 'bg-emerald-100 text-sm px-1 rounded-md';
      case 'processing':
      case 'orderconfirm':
        return 'bg-blue-100 text-sm px-1 rounded-md';
      case 'shipped':
        return 'bg-purple-100 text-sm px-1 rounded-md';
      case 'delivered':
        return 'bg-green-100 text-sm px-1 rounded-md';
      case 'receivedorder':
        return 'bg-green-200 text-sm px-1 rounded-md';
      case 'cancelled':
        return 'bg-red-100 text-sm px-1 rounded-md';
      default:
        return 'bg-gray-100 text-sm px-1 rounded-md';
    }
  }

  getExpectedDeliveryDate(orderDate: string): string {
    const date = new Date(orderDate);
    date.setDate(date.getDate() + 2);

    return date.toLocaleDateString('en-US', {
      weekday: 'long',
      year: 'numeric',
      month: 'short',
      day: 'numeric'
    });
  }

  getNextStatus(currentStatus: string, paymentMethod?: string): string {
    const statusLower = currentStatus.toLowerCase();
    const paymentMethodLower = paymentMethod?.toLowerCase();

    if (statusLower === 'pending') {
      return paymentMethodLower === 'cod' ? 'OrderConfirm' : '';
    } else if (statusLower === 'paymentreceived') {
      return 'OrderConfirm';
    } else if (statusLower === 'orderconfirm') {
      return 'Shipped';
    } else if (statusLower === 'shipped') {
      return 'Delivered';
    }

    return '';
  }

  getActionButtonText(status: string, paymentMethod?: string): string {
    const statusLower = status.toLowerCase();
    const paymentMethodLower = paymentMethod?.toLowerCase();

    if (statusLower === 'pending' && paymentMethodLower === 'cod') {
      const nextStatus = this.getNextStatus(status, paymentMethod);
      if (nextStatus) {
        return `Mark as ${nextStatus}`;
      }
    }

    const nextStatus = this.getNextStatus(status, paymentMethod);
    if (nextStatus) {
      return `Mark as ${nextStatus}`;
    }

    if (this.isCancellable(status, paymentMethod)) {
      return 'Cancel order';
    }

    return '';
  }

  isCancellable(status: string, paymentMethod?: string): boolean {
    const statusLower = status.toLowerCase();
    return statusLower === 'pending' || statusLower === 'orderconfirm';
  }

  getActionButtonClass(status: string, paymentMethod?: string): string {
    const statusLower = status.toLowerCase();
    const paymentMethodLower = paymentMethod?.toLowerCase();

    if (statusLower === 'pending' && paymentMethodLower === 'cod') {
      return 'w-full rounded-lg bg-primary-700 px-3 py-2 text-sm font-medium text-white hover:bg-primary-800 focus:outline-none focus:ring-4 focus:ring-primary-300 dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800 sm:w-auto';
    }

    const nextStatus = this.getNextStatus(status, paymentMethod);
    if (nextStatus) {
      return 'w-full rounded-lg bg-primary-700 px-3 py-2 text-sm font-medium text-white hover:bg-primary-800 focus:outline-none focus:ring-4 focus:ring-primary-300 dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800 sm:w-auto';
    }

    if (this.isCancellable(status, paymentMethod)) {
      return 'w-full rounded-lg bg-red-700 px-3 py-2 text-sm font-medium text-white hover:bg-red-800 focus:outline-none focus:ring-4 focus:ring-red-300 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900 sm:w-auto';
    }

    return '';
  }

  onStatusUpdate() {
    this.statusUpdate.emit({
      orderId: this.order.id,
      currentStatus: this.order.status,
      paymentMethod: this.order.paymentMethod
    });
  }
}
