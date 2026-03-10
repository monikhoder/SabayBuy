import { Component, inject } from '@angular/core';
import { Router, RouterLink } from "@angular/router";
import { FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { AccountService } from '../../../core/services/account.service';

@Component({
  selector: 'app-login',
  imports: [RouterLink,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  private accountService = inject(AccountService);
  private router = inject(Router);
  private fg = inject(FormBuilder);



  loginForm = this.fg.group({
    email: [''],
    password: ['']
  });
  onSubmit(){
    this.accountService.login(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUser().subscribe();
        this.router.navigateByUrl('/products');
      }
    });
  }



}
