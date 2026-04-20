import { afterNextRender, Component, inject } from '@angular/core';
import { AccountService } from '../../../core/services/account.service';
import { Router, RouterLink } from '@angular/router';
import { HasRoleDirective } from '../../../shared/directives/has-role.directive';

@Component({
  selector: 'app-profile-dropdown',
  imports: [RouterLink, HasRoleDirective],
  templateUrl: './profile-dropdown.component.html',
  styleUrl: './profile-dropdown.component.scss',
})
export class ProfileDropdownComponent {
  accountService = inject(AccountService)
  routerLink = inject(Router)

  logout() {
    this.accountService.logout().subscribe({
      next: () => {
        this.accountService.currentUser.set(null);
        this.routerLink.navigateByUrl('/')
      }
    });
  }
}


