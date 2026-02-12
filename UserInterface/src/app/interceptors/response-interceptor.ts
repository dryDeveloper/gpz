import { HttpErrorResponse, HttpEventType, HttpInterceptorFn, HttpStatusCode } from '@angular/common/http';
import { catchError, EMPTY, tap } from 'rxjs';

export const responseInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    tap(event => {
      if (event.type === HttpEventType.Response && event.status === HttpStatusCode.Created) {
        // if (event.status === HttpStatusCode.Created)
        console.log("resource created...");
        return true;
        // return event.body;
      }
      return event.type;
    }),
    catchError(error => {
      if (error instanceof HttpErrorResponse) {
        return EMPTY;
      } else throw error;
    }),
  );
};
