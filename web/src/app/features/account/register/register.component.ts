import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  validationErrors?: string[] = [];

  registerForm = this.fb.group({
    firstName: [''],
    lastName: [''],
    email: [''],
    password: ['']
  });

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => {
        alert('Registration successful! Please log in.');
        this.router.navigate(['/account/login']);
      },
      error: (err) => {
        console.error('Registration error:', err);
       this.handleErrors(err);
    }
    });
  }


  private handleErrors(err: any) {
    const parsedErrors: string[] = [];
    if (err.error && err.error.errors) {
      const serverErrors = err.error.errors;
      for (const key in serverErrors) {
        if (serverErrors[key]) {
          parsedErrors.push(...serverErrors[key]);
        }
      }
    } else if (err.error && err.error.title) {
      parsedErrors.push(err.error.title);
    } else {
      return;
    }
    this.validationErrors = parsedErrors;
  }
}
