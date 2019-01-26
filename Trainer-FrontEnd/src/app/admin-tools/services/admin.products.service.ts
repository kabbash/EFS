import { Injectable } from '@angular/core';
import { PagedResult } from '../../shared/models/paged-result';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';

@Injectable({
  providedIn: 'root'
})
export class AdminProductsService {

  constructor(private service: RepositoryService) { }

  approve(productId: Number) {
    return this.service.post("products/approve", { id: productId });
  }

  reject(productId: Number, rejectReason: string) {
    return this.service.post("products/reject", { id: productId, rejectReason: rejectReason });
  }

  delete(productId: Number) {
    return this.service.delete("products/" + productId);
  }

  getFilteredProducts(filterUrl: string) {
    return this.service.getData<PagedResult<productListItemDto>>("products/getFilteredData" + filterUrl);
  }

  update(productId: number, product: FormData): any {
    return this.service.update("products/" + productId, product);
  }

  create(product: FormData): any {
    return this.service.create("products/" , product);
  }
}
