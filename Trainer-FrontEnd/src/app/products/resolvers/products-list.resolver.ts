import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable } from 'rxjs';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ProductsListResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<productListItemDto[]>> {
    return this.repositoryService.getData<productListItemDto[]>('products/category/' + route.params['categoryId']);
  }
}
