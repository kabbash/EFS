import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { AppConfig } from '../../../config/app.config';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class ProductsListResolver implements Resolve<Observable<ResultMessage<PagedResult<productListItemDto>>>> {

    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<productListItemDto>>> {
        const pageSize = AppConfig.settings.pagination.productsForOwners.pageSize;
        return this.repositoryService.getData<PagedResult<productListItemDto>>('products/getforowners?pageNo=1&pageSize=' + pageSize).pipe(
            map((data: Observable<ResultMessage<PagedResult<productListItemDto>>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }
}