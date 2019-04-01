import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { ResultMessage } from '../../shared/models/result-message';
import { RepositoryService } from '../../shared/services/repository.service';
import { AppConfig } from '../../../config/app.config';
import { catchError } from 'rxjs/internal/operators/catchError';
import { ErrorHandlingService } from 'src/app/shared/services/error-handling.service';
import { of } from 'rxjs/internal/observable/of';
import { HttpErrorResponse } from '@angular/common/http/src/response';
import { map } from 'rxjs/internal/operators/map';
import { PAGES } from 'src/app/config/defines';

@Injectable()
export class ItemReviewResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {

    /**
     *
     */
    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) { }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<productListItemDto[]>> {
        const pageSize = AppConfig.settings.pagination.itemsForReview.pageSize;
        return this.repositoryService.getData<productListItemDto[]>('itemsreview?pageNo=1&pageSize=' + pageSize).pipe(
            map((data: Observable<ResultMessage<productListItemDto[]>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }

}
