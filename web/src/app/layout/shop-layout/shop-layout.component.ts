import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from '../header/header.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-shop-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, Header],
  template: `
    <div class="bg-gray-50 dark:bg-gray-900 min-h-screen">
      <app-header></app-header>
      <main>
        <router-outlet></router-outlet>
      </main>
    </div>
  `
})
export class ShopLayoutComponent {}
