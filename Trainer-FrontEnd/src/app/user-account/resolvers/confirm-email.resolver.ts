import { Injectable } from '@angular/core';
import { Resolve, ActivatedRoute, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { AuthService } from '../../auth/services/auth.service';
import { User } from '../../auth/models/user';
import { map, catchError } from 'rxjs/operators';
import { PAGES } from '../../config/defines';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class ConfirmEmailResolver implements Resolve<Observable<ResultMessage<User>>> {


    constructor(private authService: AuthService, private errorHandlingService: ErrorHandlingService) {
    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<User>> {
        return this.authService.verifyEmail(route.queryParams.activationToken || "").pipe(
            map((data: Observable<ResultMessage<User>>) => data), catchError(error => {
                this.errorHandlingService.handle(error, PAGES.AUTHENTICATOIN);
                return throwError(error);
            })
        );
    }
}
