import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { FoodItem } from 'src/app/shared/models/neutrints/food-item-dto';
import { NeutrintsService } from '../../shared/services/neutrints.service';
import { PagedResult } from 'src/app/shared/models/paged-result';
@Injectable()
export class FoodItemResolver implements Resolve<Observable<ResultMessage<PagedResult<FoodItem>>>> {
    constructor(private service: NeutrintsService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<PagedResult<FoodItem>>> {
        return route.params.foodItemId > 0 ? this.service.getById(route.params.foodItemId) : null;
    }
}
