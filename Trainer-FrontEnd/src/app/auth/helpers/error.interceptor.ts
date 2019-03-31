import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';
import { ErrorHandlingService } from 'src/app/shared/services/error-handling.service';
import { PAGES } from 'src/app/config/defines';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthService, private errorHandlerService: ErrorHandlingService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401) {
                // auto logout if 401 response returned from api
                this.authenticationService.logout();
            }

            this.errorHandlerService.handle(err, PAGES.HOME);

            const error = err.error.message || err.statusText;
            return throwError(error);
        }));
    }
}
