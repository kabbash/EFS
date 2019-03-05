import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable } from 'rxjs';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { Injectable } from '@angular/core';
import { AppConfig } from '../../../config/app.config';

@Injectable()
export class ProductsListResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<productListItemDto[]>> {
    let pageSize = AppConfig.settings.pagination.productsForAny.pageSize;
    return this.repositoryService.getData<productListItemDto[]>('products?isSpecial=false&pageNo=1&pageSize=' + pageSize + '&categoryId=' + route.params['categoryId']);
  }
}
