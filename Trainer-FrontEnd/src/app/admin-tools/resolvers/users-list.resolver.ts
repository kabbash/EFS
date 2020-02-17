import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { User } from '../../auth/models/user';
import { UsersService } from '../services/users.service';
import { catchError, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class UsersListResolver implements Resolve<Observable<ResultMessage<PagedResult<User>>>> {

    constructor(private service: UsersService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<User>>> {
        const pageSize = environment.usersForAdminPageSize;
        return this.service.getFilteredUsers('?PageNo=1&PageSize=' + pageSize).pipe(
            map((data: Observable<ResultMessage<PagedResult<User>>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }
}