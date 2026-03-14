import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { RegisterValidationErrors } from '../../../shared/models/regististerValidtion';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, TextInputComponent
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);
  validationErrors: RegisterValidationErrors = {};

  registerForm = this.fb.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => {
        this.router.navigate(['/account/login']);
      },
      error: (err) => {
        this.handleErrors(err);
      },
    });
  }

  private handleErrors(err: any) {
    this.validationErrors = {};

    if (err.error && err.error.errors) {
      const serverErrors = err.error.errors;

      const fields: (keyof RegisterValidationErrors)[] = [
        'firstName',
        'lastName',
        'email',
        'password',
      ];

      //loop fields
      fields.forEach((field) => {
        const matchedKey = Object.keys(serverErrors).find((key) =>
          key.toLowerCase().includes(field.toLowerCase()),
        );
        if (matchedKey) {
          this.validationErrors[field] = [];

          serverErrors[matchedKey].forEach((errorMessage: string) => {
            if (!errorMessage.includes('Username')) {
              this.validationErrors[field]!.push(errorMessage.trim());
            }
          });

          this.validationErrors[field] = [...new Set(this.validationErrors[field])];
        }
      });
    } else if (err.error && err.error.title) {
      this.validationErrors.general = [err.error.title];
    } else {
      this.validationErrors.general = ['Registration failed. Please try again.'];
    }
  }
}
