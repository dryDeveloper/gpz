import { HttpErrorResponse, HttpEventType, HttpInterceptorFn, HttpResponse, HttpStatusCode } from '@angular/common/http';
import { tap } from 'rxjs';

export const responseInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    tap(event => {
      if (event instanceof HttpResponse && event.status === HttpStatusCode.Created) {
        // if (event.status === HttpStatusCode.Created)
          // throw { code: 201, success: true };
        // return event.body;
      }
      // throw { code: 100, success: true };
    })
  );
};
