import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { inject } from '@angular/core';
import { SnackbarService } from '../services/snackbar.service';

export const roleGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);
  const snack = inject(SnackbarService);

  const allowedRoles = route.data['roles'] as string[];
  const userRole = accountService.currentUser()?.role;

  if (userRole && allowedRoles.includes(userRole)) {
    return true;
  }

  snack.error('You do not have permission to access this page');
  router.navigateByUrl('/');
  return false;
};