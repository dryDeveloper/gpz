import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError } from 'rxjs';

class HttpNoNetworkConnectionError extends Error {
  wasCaught = false;
  constructor() { super('No network connection') }
}

class UnauthorizedError extends Error {
  wasCaught = false;
  severity = 'warn';
  type = 'Session Expired';
  constructor() { super('session expired, login again...')}
}

function checkNoNetworkConnection(error: any): boolean {
  return(
    error instanceof HttpErrorResponse
    && !error.headers.keys().length
    && !error.ok
    && !error.status
    && !error.error.loaded
    && !error.error.total
  )
}

export const serverErrorInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    catchError(error => {
      if (error instanceof HttpErrorResponse && checkNoNetworkConnection(error)) {
        const networkError = new HttpNoNetworkConnectionError();
        console.warn(networkError);
        networkError.wasCaught = true;
        throw networkError;
      }
      else if (error instanceof HttpErrorResponse && error.status === 401) {
        const expiredSessionError = new UnauthorizedError();
        console.warn(expiredSessionError);
        expiredSessionError.wasCaught = true;
        throw expiredSessionError;
      }
      throw error;
    })
  );
};
