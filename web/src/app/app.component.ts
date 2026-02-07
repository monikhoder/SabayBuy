import { Component,signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "./layout/header/header.component";
import { HomeComponent } from "./features/home/home.component";
import { ProductListComponent } from "./features/product-list/product-list.component";

@Component({
  selector: 'app-root',
  imports: [Header, HomeComponent, ProductListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  protected readonly title = signal('web');
}
