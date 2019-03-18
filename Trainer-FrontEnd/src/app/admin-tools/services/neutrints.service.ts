import { Injectable } from '@angular/core';
import { PagedResult } from '../../shared/models/paged-result';
import { RepositoryService } from '../../shared/services/repository.service';
import { foodItem } from 'src/app/shared/models/neutrints/food-item-dto';

@Injectable({
  providedIn: 'root'
})
export class NeutrintsService {

  constructor(private service: RepositoryService) { }

  delete(foodItemId: Number) {
    return this.service.delete("FoodItems/" + foodItemId);
  }

  get(filterUrl: string) {
    return this.service.getData<PagedResult<foodItem>>("FoodItems" + filterUrl);
  }

  getById(id: number) {
    return this.service.getData<PagedResult<foodItem>>("FoodItems/" + id);
  }

  update(foodItemId: number, foodItem: FormData): any {
    return this.service.update("FoodItems/" + foodItemId, foodItem);
  }

  add(foodItem: FormData): any {
    return this.service.postForm("FoodItems" , foodItem);
  }
}
