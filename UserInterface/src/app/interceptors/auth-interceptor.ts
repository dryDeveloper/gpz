import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth-service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  let inMemoryToken = inject(AuthService).token();
  let localToken = localStorage.getItem("token");

  if (localToken && localToken != inMemoryToken)
    localStorage.setItem("token", inMemoryToken)
  // if (inMemoryToken =! localToken) localStorage.setItem("token", inMemoryToken);

  if (req.url.endsWith("login"))
    return next(req);

  const newReq = req.clone({
    headers: req.headers.append('Authentication', "Bearer " + localToken)
  });

  return next(newReq);
};
