import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { AnalyticsService } from '../../../core/services/analytics.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import {
  AdminDashboard,
  DashboardSummary,
  LowStockProduct,
  NameValue,
  RecentOrder,
  RevenueByDay,
  TopProduct
} from '../../../shared/models/adminDashboard';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink, MatIconModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit {
  private analyticsService = inject(AnalyticsService);
  private snack = inject(SnackbarService);

  dashboard?: AdminDashboard;
  loading = false;

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard() {
    this.loading = true;

    this.analyticsService.getAdminDashboard().subscribe({
      next: (dashboard) => {
        this.dashboard = dashboard;
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.snack.error(error.message || 'Failed to load admin dashboard');
      }
    });
  }

  get summary(): DashboardSummary | undefined {
    return this.dashboard?.summary;
  }

  get revenueByDay(): RevenueByDay[] {
    return this.dashboard?.revenueByDay ?? [];
  }

  get ordersByStatus(): NameValue[] {
    return this.dashboard?.ordersByStatus ?? [];
  }

  get ordersBySource(): NameValue[] {
    return this.dashboard?.ordersBySource ?? [];
  }

  get recentOrders(): RecentOrder[] {
    return this.dashboard?.recentOrders ?? [];
  }

  get topProducts(): TopProduct[] {
    return this.dashboard?.topProducts ?? [];
  }

  get lowStockProducts(): LowStockProduct[] {
    return this.dashboard?.lowStockProducts ?? [];
  }

  get maxRevenue(): number {
    return Math.max(...this.revenueByDay.map(item => item.revenue), 1);
  }

  get maxStatusCount(): number {
    return Math.max(...this.ordersByStatus.map(item => item.value), 1);
  }

  get maxSourceCount(): number {
    return Math.max(...this.ordersBySource.map(item => item.value), 1);
  }

  get totalSourceOrders(): number {
    return this.ordersBySource.reduce((total, item) => total + item.value, 0);
  }

  getRevenueHeight(revenue: number): number {
    return Math.max((revenue / this.maxRevenue) * 100, revenue > 0 ? 8 : 2);
  }

  getPercent(value: number, max: number): number {
    if (max <= 0) return 0;
    return Math.round((value / max) * 100);
  }

  getSourcePercent(value: number): number {
    if (this.totalSourceOrders <= 0) return 0;
    return Math.round((value / this.totalSourceOrders) * 100);
  }

  getStatusBadgeClass(status: string) {
    switch (status) {
      case 'Pending':
        return 'bg-yellow-100 text-yellow-800 dark:bg-yellow-900 dark:text-yellow-300';
      case 'PaymentReceived':
      case 'OrderConfirm':
      case 'ReceivedOrder':
      case 'Completed':
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

  getStockBadgeClass(stock: number) {
    if (stock <= 3) return 'bg-red-100 text-red-800 dark:bg-red-900 dark:text-red-300';
    if (stock <= 10) return 'bg-yellow-100 text-yellow-800 dark:bg-yellow-900 dark:text-yellow-300';
    return 'bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300';
  }
}
