import { Resolve} from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ProductCategoryDTO } from '../../shared/models/products/product-category-dto';
import { Injectable } from '@angular/core';

@Injectable()
export class ProductsCategoriesResolver implements Resolve<Observable<ResultMessage<ProductCategoryDTO[]>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(): Observable<ResultMessage<ProductCategoryDTO[]>> {
    return this.repositoryService.getData<ProductCategoryDTO[]>('products/categories');
  }
}
