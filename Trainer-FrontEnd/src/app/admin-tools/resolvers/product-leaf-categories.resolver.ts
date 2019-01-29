import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { ProductCategoryDTO } from 'src/app/shared/models/product-category-dto';

@Injectable()
export class LeafProductCategoriesResolver implements Resolve<Observable<ResultMessage<ProductCategoryDTO[]>>>{

    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<ProductCategoryDTO[]>> {
        return this.repositoryService.getData<ProductCategoryDTO[]>('Products/Categories');
    }
}