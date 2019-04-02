import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { RepositoryService } from '../../shared/services/repository.service';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
@Injectable()
export class ProductDetailsResolver implements Resolve<Observable<ResultMessage<any>>> {
    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<any>> {
        return route.params.productId > 0 ? this.repositoryService.getData('products/' + route.params.productId).pipe(
            map((data: Observable<ResultMessage<any>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        ) : null;
    }
}
