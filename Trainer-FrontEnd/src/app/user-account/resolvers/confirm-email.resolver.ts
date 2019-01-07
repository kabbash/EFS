import { Injectable } from '@angular/core';
import { Resolve, ActivatedRoute, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { AuthService } from '../../auth/services/auth.service';
import { User } from '../../auth/models/user';

@Injectable()
export class ConfirmEmailResolver implements Resolve<Observable<ResultMessage<User>>> {


    constructor(private authService: AuthService) {
    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<User>> {
        return this.authService.verifyEmail(route.queryParams.activationToken || "");
    }
}
