import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { initFlowbite } from 'flowbite';
import { Header } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Category } from './shared/models/category';
import { Pagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class AppComponent implements OnInit {
  protected readonly title = signal('web');
  baseUrl = 'http://localhost:5110/api/';
  private http = inject(HttpClient);
  Categories: Category[] = [];

  ngOnInit(): void {
    initFlowbite();
   this.http.get<Pagination<Category>>(this.baseUrl + 'Categories?isParent=true').subscribe({
      next: (response) => {
        this.Categories = response.data;
      },
      error: (error) => console.error(error)
    });
  }

}
