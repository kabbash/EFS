import { Injectable } from '@angular/core';
import { PagedResult } from '../models/paged-result';
import { RepositoryService } from './repository.service';
import { FoodItem } from 'src/app/shared/models/neutrints/food-item-dto';

@Injectable({
  providedIn: 'root'
})
export class NeutrintsService {

  constructor(private service: RepositoryService) { }

  delete(foodItemId: Number) {
    return this.service.delete("FoodItems/" + foodItemId);
  }

  get(filterUrl: string) {
    return this.service.getData<PagedResult<FoodItem>>("FoodItems" + filterUrl);
  }

  getById(id: number) {
    return this.service.getData<PagedResult<FoodItem>>("FoodItems/" + id);
  }

  update(foodItemId: number, foodItem: FormData): any {
    return this.service.update("FoodItems/" + foodItemId, foodItem);
  }

  add(foodItem: FormData): any {
    return this.service.postForm("FoodItems" , foodItem);
  }
}
