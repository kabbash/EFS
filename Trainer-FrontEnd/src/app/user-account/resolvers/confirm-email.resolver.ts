import { Injectable } from '@angular/core';
import { Resolve, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { AuthService } from 'src/app/auth/services/auth.service';

@Injectable()
export class ConfirmEmailResolver implements Resolve<Observable<ResultMessage<User>>> {
    private activationToken: "";

    constructor(private authService: AuthService, private route: ActivatedRoute) {
    }

    resolve(): Observable<ResultMessage<User>> {
        debugger;
        this.route.queryParams.subscribe(params => this.activationToken = params.activationToken || "")
        return this.authService.verifyEmail(this.activationToken);
    }
}
