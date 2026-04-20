import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin-badge',
  standalone: true,
  imports: [CommonModule],
  template: `
    <span [ngClass]="getBadgeClass()" class="text-xs font-medium me-2 px-2.5 py-0.5 rounded">
        {{ label }}
    </span>
  `
})
export class AdminBadgeComponent {
  @Input() label: string = '';
  @Input() type: string = '';

  getBadgeClass(): string {
    const value = (this.type || this.label).toLowerCase();
    switch (value) {
      // Roles
      case 'admin':
        return 'bg-blue-100 text-blue-800 dark:bg-blue-900 dark:text-blue-300';
      case 'stock':
        return 'bg-purple-100 text-purple-800 dark:bg-purple-900 dark:text-purple-300';
      case 'seller':
        return 'bg-orange-100 text-orange-800 dark:bg-orange-900 dark:text-orange-300';
      case 'customer':
        return 'bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300';
      
      // Order Statuses
      case 'pending':
        return 'bg-yellow-100 text-yellow-800 dark:bg-yellow-900 dark:text-yellow-300';
      case 'paymentreceived':
        return 'bg-emerald-100 text-emerald-800 dark:bg-emerald-900 dark:text-emerald-300';
      case 'orderconfirm':
      case 'processing':
        return 'bg-blue-100 text-blue-800 dark:bg-blue-900 dark:text-blue-300';
      case 'shipped':
        return 'bg-purple-100 text-purple-800 dark:bg-purple-900 dark:text-purple-300';
      case 'delivered':
        return 'bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300';
      case 'receivedorder':
        return 'bg-green-200 text-green-800 dark:bg-green-800 dark:text-green-200';
      case 'cancelled':
        return 'bg-red-100 text-red-800 dark:bg-red-900 dark:text-red-300';
        
      default:
        return 'bg-gray-100 text-gray-800 dark:bg-gray-700 dark:text-gray-300';
    }
  }
}
