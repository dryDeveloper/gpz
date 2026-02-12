import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/authentication/auth-service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const inMemoryToken = inject(AuthService).token();
  const localToken = localStorage.getItem("token");

  if (localToken && localToken != inMemoryToken)
    localStorage.setItem("token", inMemoryToken)
  // if (inMemoryToken =! localToken) localStorage.setItem("token", inMemoryToken);

  if (req.url.endsWith("login"))
    return next(req);

  const newReq = req.clone({
    headers: req.headers.append('Authorization', "Bearer " + inMemoryToken)
  });

  return next(newReq);
};
