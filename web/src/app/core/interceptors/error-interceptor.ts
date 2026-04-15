import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const snack = inject(SnackbarService);

  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      if (err.status === 0) {
        snack.error('Unable to connect to the server. Please try again later.');
        router.navigateByUrl('/server-error', { state: { error: 'Unable to connect to the server' } });
      }
      if (err.status === 404) {
        snack.error('The requested page was not found.');
        router.navigateByUrl('/not-found');
      }
      if (err.status === 500) {
        snack.error('An unexpected error occurred on the server. Please try again later.');
        router.navigateByUrl('/server-error', { state: { error: err.error } });
      }
      //api server down
      return throwError(() => err);
    }),
  );
};
