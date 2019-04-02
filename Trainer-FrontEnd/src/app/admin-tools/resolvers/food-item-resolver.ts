import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { FoodItem } from '../../shared/models/neutrints/food-item-dto';
import { NeutrintsService } from '../../shared/services/neutrints.service';
import { PagedResult } from '../../shared/models/paged-result';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
@Injectable()
export class FoodItemResolver implements Resolve<Observable<ResultMessage<PagedResult<FoodItem>>>> {
    constructor(private service: NeutrintsService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<PagedResult<FoodItem>>> {
        return route.params.foodItemId > 0 ? this.service.getById(route.params.foodItemId).pipe(
            map((data: Observable<ResultMessage<PagedResult<FoodItem>>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        ) : null;
    }
}
