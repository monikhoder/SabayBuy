import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-search',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <form class="flex items-center" (submit)="$event.preventDefault()">
        <label for="admin-search" class="sr-only text-sm font-medium text-gray-900 dark:text-white">Search</label>
        <div class="relative w-full">
            <div class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                <svg aria-hidden="true" class="w-5 h-5 text-gray-500 dark:text-gray-400" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                </svg>
            </div>
            <input 
                #searchInput
                type="search" 
                id="admin-search" 
                (input)="onSearch(searchInput.value)" 
                (keyup.enter)="onSearch(searchInput.value)" 
                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full pl-10 p-2 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500" 
                [placeholder]="placeholder" 
                required="">
            <button 
                type="button" 
                (click)="onSearch(searchInput.value)" 
                class="absolute bottom-0 right-0 top-0 rounded-r-lg bg-primary-700 px-4 py-2 text-sm font-medium text-white hover:bg-primary-800 focus:outline-none focus:ring-4 focus:ring-primary-300 dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800">
                Search
            </button>
        </div>
    </form>
  `,
  styles: []
})
export class AdminSearchComponent {
  @Input() placeholder: string = 'Search...';
  @Output() search = new EventEmitter<string>();

  onSearch(value: string) {
    this.search.emit(value);
  }
}
