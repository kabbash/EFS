import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { ProductCategoryDTO } from '../../shared/models/products/product-category-dto';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class LeafProductCategoriesResolver implements Resolve<Observable<ResultMessage<ProductCategoryDTO[]>>>{

    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<ProductCategoryDTO[]>> {
        return this.repositoryService.getData<ProductCategoryDTO[]>('Products/Categories').pipe(
            map((data: Observable<ResultMessage<ProductCategoryDTO[]>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }
}
