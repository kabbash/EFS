import { Resolve} from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { Injectable } from '@angular/core';
import { productListItemDto } from 'src/app/shared/models/product-list-item-dto';
import { ActivatedRouteSnapshot } from '@angular/router/src/router_state';

@Injectable()
export class ProdcutRatingResolver implements Resolve<Observable<ResultMessage<productListItemDto>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<productListItemDto>> {
    return this.repositoryService.getData<productListItemDto>('itemsreview/' + route.params['productId']);
  }
}