import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { ResultMessage } from '../../shared/models/result-message';
import { RepositoryService } from '../../shared/services/repository.service';
import { catchError } from 'rxjs/internal/operators/catchError';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { HttpErrorResponse } from '@angular/common/http';
import { map } from 'rxjs/internal/operators/map';
import { environment } from '../../../environments/environment';

@Injectable()
export class ItemReviewResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {

    /**
     *
     */
    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) { }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<productListItemDto[]>> {
        const pageSize = environment.itemsForReviewPageSize;
        return this.repositoryService.getData<productListItemDto[]>('itemsreview?pageNo=1&pageSize=' + pageSize).pipe(
            map((data: Observable<ResultMessage<productListItemDto[]>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }

}
