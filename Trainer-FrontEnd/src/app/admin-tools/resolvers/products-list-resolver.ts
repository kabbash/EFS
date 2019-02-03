import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { AppConfig } from '../../../config/app.config';

@Injectable()
export class AdminProductsListResolver implements Resolve<Observable<ResultMessage<PagedResult<productListItemDto>>>> {

    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<productListItemDto>>> {
        let pageSize = AppConfig.settings.pagination.productsForAdmin.pageSize;
        return this.repositoryService.getData<PagedResult<productListItemDto>>('products/getforadmin?pageNo=1&pageSize='+pageSize);
    }
}