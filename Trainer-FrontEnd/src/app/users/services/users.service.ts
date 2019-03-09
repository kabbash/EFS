import { Injectable } from '@angular/core';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private service: RepositoryService) { }

  delete(productId: Number) {
    return this.service.delete("products/" + productId);
  }

  getFilteredProducts(filterUrl: string) {
    return this.service.getData<PagedResult<productListItemDto>>("products/getforowners" + filterUrl);
  }

  update(productId: number, product: FormData): any {
    return this.service.update("products/" + productId, product);
  }

  add(product: FormData): any {
    return this.service.postForm("products" , product);
  }
}
