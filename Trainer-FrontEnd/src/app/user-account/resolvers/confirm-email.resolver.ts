import { Injectable } from '@angular/core';
import { Resolve, ActivatedRoute, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { AuthService } from 'src/app/auth/services/auth.service';
import { User } from 'src/app/auth/models/user';

@Injectable()
export class ConfirmEmailResolver implements Resolve<Observable<ResultMessage<User>>> {
    

    constructor(private authService: AuthService) {
    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<User>> {
        debugger;
        return this.authService.verifyEmail(route.queryParams.activationToken || "");
    }
}
