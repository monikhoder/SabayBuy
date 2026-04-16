import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { CartComponent } from './features/cart/cart.component';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';
import { CheckoutComponent } from './features/checkout/checkout.component';
import { SuccessPageComponent } from './features/checkout/success-page/success-page.component';
import { authGuard } from './core/guards/auth-guard';
import { emptyCartGuard } from './core/guards/empty-cart-guard';
import { OrderComponent } from './features/orders/order.component';
import { OrderDetailedComponent } from './features/orders/order-detailed/order-detailed.component';
import { orderCompleteGuard } from './core/guards/order-complete-guard';
import { roleGuard } from './core/guards/role-guard';
import { ShopLayoutComponent } from './layout/shop-layout/shop-layout.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { ProductListComponent } from './features/Shopping/product-list/product-list.component';
import { ProductDetailsComponent } from './features/Shopping/product-details/product-details.component';
import { DashboardComponent } from './features/admin/dashboard/dashboard.component';
import { ProductsComponent } from './features/admin/products/products.component';
import { OrdersComponent } from './features/admin/orders/orders.component';
import { CategoriesComponent } from './features/admin/categories/categories.component';

export const routes: Routes = [
  // Shop Routes
  {
    path: '',
    component: ShopLayoutComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'products', component: ProductListComponent },
      { path: 'product/:id', component: ProductDetailsComponent },
      { path: 'cart', component: CartComponent },
      { path: 'checkout', component: CheckoutComponent, canActivate: [authGuard, emptyCartGuard] },
      { path: 'checkout/success', component: SuccessPageComponent, canActivate: [authGuard, orderCompleteGuard] },
      { path: 'orders', component: OrderComponent, canActivate: [authGuard] },
      { path: 'orders/:id', component: OrderDetailedComponent, canActivate: [authGuard] },
      { path: 'account/login', component: LoginComponent },
      { path: 'account/register', component: RegisterComponent },
      { path: 'not-found', component: NotFoundComponent },
      { path: 'server-error', component: ServerErrorComponent },
    ]
  },

  // Admin Routes
  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Admin', 'Stock', 'Seller'] },
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'products', component: ProductsComponent, canActivate: [roleGuard], data: { roles: ['Admin', 'Stock'] } },
      { path: 'orders', component: OrdersComponent },
      {path: 'categories', component: CategoriesComponent, canActivate: [roleGuard], data: { roles: ['Admin', 'Stock'] }},
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
    ]
  },

  { path: '**', redirectTo: '/not-found', pathMatch: 'full' }
];
