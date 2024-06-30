import { HttpInterceptorFn } from '@angular/common/http';

export const loggerInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('authToken');

  if(token) {
    req = req.clone({
        setHeaders: { Authorization: `Bearer ${token}` },
    });
  }

  return next(req);
};
