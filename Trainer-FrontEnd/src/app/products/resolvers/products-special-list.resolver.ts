import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable, throwError } from 'rxjs';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { Injectable } from '@angular/core';
import { AppConfig } from '../../../config/app.config';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';

@Injectable()
export class ProductsSpecialListResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {
  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<productListItemDto[]>> {
    // let pageSize = AppConfig.settings.pagination.specialProductsForAny.pageSize;
    // get all for first time and then handle it throw client side
    const pageSize = 50 ;
    return this.repositoryService.getData<productListItemDto[]>('products?isSpecial=true&pageNo=1&pageSize='
    + pageSize + '&categoryId=' + route.params['categoryId']).pipe(
      map((data: Observable<ResultMessage<productListItemDto[]>>) => data), catchError((error: HttpErrorResponse) => {
        this.errorHandlingService.handle(error, PAGES.PRODUCTS);
        return throwError(error);
      })
    );
  }
}
