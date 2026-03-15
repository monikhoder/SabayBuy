import { Component, inject, Signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from "@angular/router";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { AccountService } from '../../../core/services/account.service';
import { TextInputComponent } from '../../../shared/components/text-input/text-input.component';

@Component({
  selector: 'app-login',
  imports: [RouterLink,
    ReactiveFormsModule,
    TextInputComponent
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  private accountService = inject(AccountService);
  private router = inject(Router);
  private fg = inject(FormBuilder);
  private activatedRoute = inject(ActivatedRoute);
  returnURL = '/products';
  loginError: string | null = null;

  constructor(){
    const url = this.activatedRoute.snapshot.queryParamMap.get('returnUrl');
    if(url){
      this.returnURL = url;
    }
  }


  loginForm = this.fg.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  });
  onSubmit(){
    this.accountService.login(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUser().subscribe();
        this.router.navigateByUrl(this.returnURL);
      },
      error: (err) => {
        this.handleErrors(err);
      }
    });
  }



  private handleErrors(err: any) {
    this.loginError = null;
    if (err.status === 401) {
      this.loginError = 'Invalid email or password. Please try again.';
    } else {
      this.loginError = 'An unexpected error occurred. Please try again later.';
    }
  }

}
