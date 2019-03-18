import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { foodItem } from 'src/app/shared/models/neutrints/food-item-dto';
import { NeutrintsService } from '../services/neutrints.service';
import { PagedResult } from 'src/app/shared/models/paged-result';
import { AppConfig } from 'src/config/app.config';
@Injectable()
export class FoodItemsListResolver implements Resolve<Observable<ResultMessage<PagedResult<foodItem>>>> {
    constructor(private service: NeutrintsService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<PagedResult<foodItem>>> {
        let pageSize = AppConfig.settings.pagination.neutrintsForAdmin.pageSize;
        return this.service.get('?pageNo=1&pageSize=' + pageSize);
    }
}
