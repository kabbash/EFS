import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { AppConfig } from '../../../config/app.config';

@Injectable()
export class ProductsListResolver implements Resolve<Observable<ResultMessage<PagedResult<productListItemDto>>>> {

    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<productListItemDto>>> {
        let pageSize = AppConfig.settings.pagination.productsForOwners.pageSize;
        return this.repositoryService.getData<PagedResult<productListItemDto>>('products/getforowners?pageNo=1&pageSize='+pageSize);
    }
}