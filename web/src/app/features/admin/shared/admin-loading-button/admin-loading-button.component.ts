import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-admin-loading-button',
  standalone: true,
  imports: [CommonModule, MatProgressSpinnerModule],
  template: `
    <button 
        [type]="type" 
        [disabled]="disabled || loading" 
        [class]="btnClass + ' flex items-center justify-center disabled:opacity-50 disabled:cursor-not-allowed'">
        @if (loading) {
            <mat-spinner diameter="20" class="mr-2"></mat-spinner>
            <span>{{ loadingText }}</span>
        } @else {
            <ng-content></ng-content>
        }
    </button>
  `
})
export class AdminLoadingButtonComponent {
  @Input() type: 'button' | 'submit' = 'button';
  @Input() loading = false;
  @Input() disabled = false;
  @Input() loadingText = 'Processing...';
  @Input() btnClass = 'text-white bg-primary-700 hover:bg-primary-800 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800';
}
