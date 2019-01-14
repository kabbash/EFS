import { Injectable } from '@angular/core';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';

@Injectable({
  providedIn: 'root'
})
export class AdminProductsService {

  constructor(private service: RepositoryService) { }

  approve(productId) {
    return this.service.post("products/approve", { id: productId });
  }

  reject(productId) {
    return this.service.post("products/reject", { id: productId });
  }

  delete(productId) {
    return this.service.delete("products/" + productId);
  }

  getFilteredProducts(filterUrl) {
    return this.service.getData<PagedResult<productListItemDto>>("products/getFilteredData" + filterUrl);
  }
}
