import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { OrderService } from '../../../core/services/order.service';
import { Order } from '../../../shared/models/order';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { AdminService } from '../../../core/services/admin.service';
import { AccountService } from '../../../core/services/account.service';

@Component({
  selector: 'app-order-detailed',
  imports: [
    RouterLink,
    CurrencyPipe,
    DatePipe,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './order-detailed.component.html',
  styleUrl: './order-detailed.component.scss',
})
export class OrderDetailedComponent implements OnInit {
  private orderService = inject(OrderService);
  private adminService = inject(AdminService);
  accountService = inject(AccountService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  order: Order | null = null;
  backRoute: string = '/orders';

  ngOnInit(): void {
    this.determineBackRoute();
    this.loadOrder();
  }

  determineBackRoute() {
    // Get returnUrl from query parameters, default based on user role
    const returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
    if (returnUrl) {
      this.backRoute = returnUrl;
    } else {
      const currentUser = this.accountService.currentUser();
      if (currentUser?.role === 'Admin' || currentUser?.role === 'Seller') {
        this.backRoute = '/admin/orders';
      } else {
        this.backRoute = '/orders';
      }
    }
  }

  loadOrder() {
    const id = this.route.snapshot.paramMap.get('id');
    if (!id) return;


       this.orderService.getOrderById(id).subscribe({
      next: (order) => {
        this.order = order;
      },
      error: (error) => {
        console.error('Error loading order:', error);
      }
    });
  }
}

