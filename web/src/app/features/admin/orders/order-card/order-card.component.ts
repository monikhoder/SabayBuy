import { Component, Input, Output, EventEmitter, inject } from '@angular/core';
import { Order } from '../../../../shared/models/order';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { AdminBadgeComponent } from './../../shared/admin-badge/admin-badge.component';
import { AdminService } from '../../../../core/services/admin.service';
import { SnackbarService } from '../../../../core/services/snackbar.service';

@Component({
  selector: 'app-order-card',
  standalone: true,
  imports: [CommonModule, RouterLink, MatButtonModule, AdminBadgeComponent],
  templateUrl: './order-card.component.html',
  styleUrl: './order-card.component.scss',
})
export class OrderCardComponent {
  private adminService = inject(AdminService);
  private snack = inject(SnackbarService);

  @Input() order!: Order;
  @Output() statusUpdate = new EventEmitter<{ orderId: string, targetStatus: string }>();

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

  isCancellable(status: string): boolean {
    const statusLower = status.toLowerCase();
    return statusLower === 'pending' || statusLower === 'orderconfirm' || statusLower === 'paymentreceived';
  }

  onStatusUpdate(targetStatus: string) {
    this.statusUpdate.emit({
      orderId: this.order.id,
      targetStatus: targetStatus
    });
  }

  downloadInvoice() {
    this.adminService.downloadOrderInvoice(this.order.id).subscribe({
      next: (pdfBlob) => {
        const url = window.URL.createObjectURL(pdfBlob);
        const link = document.createElement('a');

        link.href = url;
        link.download = `invoice-${this.order.id.substring(0, 8).toUpperCase()}.pdf`;
        link.click();

        window.URL.revokeObjectURL(url);
      },
      error: (error) => this.snack.error(error.error || 'Failed to download invoice')
    });
  }
}
