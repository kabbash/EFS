import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { productListItemDto } from "../../shared/models/product-list-item-dto";
import { ResultMessage } from "../../shared/models/result-message";
import { RepositoryService } from "../../shared/services/repository.service";

@Injectable()
export class ItemReviewResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {

    /**
     *
     */
    constructor(private repositoryService: RepositoryService) {}
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<productListItemDto[]>> {
        return this.repositoryService.getData<productListItemDto[]>('itemsreview');
    }

}