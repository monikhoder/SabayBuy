import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { OrderService } from '../../../core/services/order.service';
import { Order } from '../../../shared/models/order';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { SignalrService } from '../../../core/services/signalr.service';

@Component({
  selector: 'app-success-page',
  standalone: true,
  imports: [RouterLink, DatePipe, CurrencyPipe],
  templateUrl: './success-page.component.html',
  styleUrl: './success-page.component.scss',
})
export class SuccessPageComponent implements OnInit , OnDestroy  {
  private orderService = inject(OrderService);
  private signalRService = inject(SignalrService);
  private router = inject(Router);
  order?: Order;

  ngOnInit(): void {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation?.extras.state as { orderId: string };
    const orderId = state?.orderId || history.state.orderId;

    if (orderId && this.orderService.orderComplete == true ) {
      this.orderService.getOrderById(orderId).subscribe({
        next: (order) => (this.order = order),
        error: (err) => console.error('Error fetching order', err),
      });
    } else {
      this.router.navigate(['/products']);
    }

  }
  ngOnDestroy(): void{
    this.orderService.orderComplete = false;
    this.signalRService.orderSignal.set(null);
  }
}
