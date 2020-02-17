import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { FoodItem } from '../../shared/models/neutrints/food-item-dto';
import { NeutrintsService } from '../../shared/services/neutrints.service';
import { PagedResult } from '../../shared/models/paged-result';
import { catchError, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { environment } from '../../../environments/environment';
@Injectable()
export class FoodItemsListResolver implements Resolve<Observable<ResultMessage<PagedResult<FoodItem>>>> {
    constructor(private service: NeutrintsService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<PagedResult<FoodItem>>> {
        const pageSize = environment.neutrintsForAdminPageSize;
        return this.service.get('?pageNo=1&pageSize=' + pageSize).pipe(
            map((data: Observable<ResultMessage<PagedResult<FoodItem>>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            })
        );
    }
}
