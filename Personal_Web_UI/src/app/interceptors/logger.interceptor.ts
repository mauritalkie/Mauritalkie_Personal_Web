import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from '../../environments/environment';

export const loggerInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('authToken');
  const backendUrl = environment.apiUrl;

  if(token && req.url.startsWith(backendUrl)) {
    req = req.clone({
        setHeaders: { Authorization: `Bearer ${token}` },
    });
  }

  return next(req);
};
