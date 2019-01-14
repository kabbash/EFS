import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleListItemDto } from '../../shared/models/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/product-list-item-dto';

@Injectable()
export class AdminProductsListResolver implements Resolve<Observable<ResultMessage<PagedResult<productListItemDto>>>> {

    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<productListItemDto>>> {
        debugger;
        return this.repositoryService.getData<PagedResult<productListItemDto>>('products/getFilteredData?pageNo=1&pageSize=10&searchText=&status=0');
    }
}