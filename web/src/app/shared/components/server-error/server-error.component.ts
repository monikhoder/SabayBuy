import { Component } from '@angular/core';

@Component({
  selector: 'app-server-error',
  imports: [],
  templateUrl: './server-error.component.html',
  styleUrl: './server-error.component.scss',
})
export class ServerErrorComponent {
  error: string | null = null;

  constructor() {
    const navigation = history.state;
    this.error = navigation?.error || 'An unexpected error occurred.';
  }

}
