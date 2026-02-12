import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { MessageService } from 'primeng/api';
// import { Toast } from 'primeng/toast';
import { catchError, tap } from 'rxjs';

class HttpNoNetworkConnectionError extends Error {
  wasCaught = false;
  constructor() { super('No network connection') }
}

function checkNoNetworkConnection(error: any): boolean {
  return(
    error instanceof HttpErrorResponse
    && !error.headers.keys().length
    && error.ok
    && !error.status
    && !error.error.loaded
    && !error.error.total
  )
}

export const serverErrorInterceptor: HttpInterceptorFn = (req, next) => {
  // const toast = inject(Toast);
  return next(req).pipe(
    tap(),
    catchError(error => {
      if (error instanceof HttpErrorResponse && error.status == 0) {
      // if (checkNoNetworkConnection(error)) {
        const error = new HttpNoNetworkConnectionError();
        console.warn(error);
        error.wasCaught = true;
        throw error;
      }
      throw error;
    })
  );
};
