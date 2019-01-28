import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { productListItemDto } from "../../shared/models/product-list-item-dto";
import { ResultMessage } from "../../shared/models/result-message";
import { RepositoryService } from "../../shared/services/repository.service";
import { AppConfig } from "src/config/app.config";

@Injectable()
export class ItemReviewResolver implements Resolve<Observable<ResultMessage<productListItemDto[]>>> {

    /**
     *
     */
    constructor(private repositoryService: RepositoryService) { }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<productListItemDto[]>> {
        let pageSize = AppConfig.settings.pagination.itemsForReview.pageSize;
        return this.repositoryService.getData<productListItemDto[]>('itemsreview?pageNo=1&pageSize=' + pageSize);
    }

}