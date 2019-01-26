import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { RepositoryService } from '../../shared/services/repository.service';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
@Injectable()
export class ProductResolver implements Resolve<Observable<ResultMessage<any>>> {
    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<any>> {
        return route.params.productId > 0 ? this.repositoryService.getData('products/' + route.params.productId) : null;
    }
}
