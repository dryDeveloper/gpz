import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withViewTransitions } from '@angular/router';
import Aura from '@primeuix/themes/aura';

import { routes } from './app.routes';
import { providePrimeNG } from 'primeng/config';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './interceptors/auth-interceptor';
import { responseInterceptor } from './interceptors/response-interceptor';
import { serverErrorInterceptor } from './interceptors/server-error-interceptor';
import { MessageService } from 'primeng/api';

export const appConfig: ApplicationConfig = {
  providers: [
    MessageService,
    provideHttpClient(
      withFetch(),
      withInterceptors([authInterceptor, serverErrorInterceptor, responseInterceptor])
    ),
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes, withViewTransitions()),
    providePrimeNG({
      theme: {
        preset: Aura
      },
      ripple: true
    }),
  ]
};
