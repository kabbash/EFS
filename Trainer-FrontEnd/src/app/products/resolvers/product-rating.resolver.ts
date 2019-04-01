import { Resolve} from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { Injectable } from '@angular/core';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { ActivatedRouteSnapshot } from '@angular/router';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';

@Injectable()
export class ProdcutRatingResolver implements Resolve<Observable<ResultMessage<productListItemDto>>> {
  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<productListItemDto>> {
    return this.repositoryService.getData<productListItemDto>('itemsreview/' + route.params['productId']).pipe(
      map((data: Observable<ResultMessage<productListItemDto>>) => data), catchError((error: HttpErrorResponse) => {
        this.errorHandlingService.handle(error, PAGES.RATING);
        return throwError(error);
      })
    );
  }
}
