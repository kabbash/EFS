import { Resolve} from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ProductCategoryDTO } from '../../shared/models/products/product-category-dto';
import { Injectable } from '@angular/core';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';

@Injectable()
export class ProductsCategoriesResolver implements Resolve<Observable<ResultMessage<ProductCategoryDTO[]>>> {
  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(): Observable<ResultMessage<ProductCategoryDTO[]>> {
    return this.repositoryService.getData<ProductCategoryDTO[]>('products/categories').pipe(
      map((data: Observable<ResultMessage<ProductCategoryDTO[]>>) => data), catchError((error: HttpErrorResponse) => {
        this.errorHandlingService.handle(error, PAGES.PRODUCTS);
        return throwError(error);
      })
    );
  }
}
