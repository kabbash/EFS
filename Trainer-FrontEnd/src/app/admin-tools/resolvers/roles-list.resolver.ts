import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { Role } from '../../shared/models/users/role.dto';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class RolesResolver implements Resolve<Observable<ResultMessage<Role>>> {

    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<Role>> {
        return this.repositoryService.getData<Role>('users/getAllRoles').pipe(
            map((data: Observable<ResultMessage<Role>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }
}