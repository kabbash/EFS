import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { ResultMessage } from "../../shared/models/result-message";
import { BannerDto } from "../../shared/models/banner.dto";
import { Observable, throwError } from "rxjs";
import { RepositoryService } from "../../shared/services/repository.service";
import { AppConfig } from "../../../config/app.config";
import { ErrorHandlingService } from "src/app/shared/services/error-handling.service";
import { PAGES } from "src/app/config/defines";
import { map } from "rxjs/internal/operators/map";
import { catchError } from "rxjs/internal/operators/catchError";
import { observable } from "rxjs/internal/symbol/observable";
import { of } from "rxjs/internal/observable/of";
import { HttpErrorResponse } from "@angular/common/http";

@Injectable()
export class BannersResolver implements Resolve<ResultMessage<BannerDto[]>>{
    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {

    }
    resolve(): ResultMessage<BannerDto[]> | Observable<ResultMessage<BannerDto[]>> | Promise<ResultMessage<BannerDto[]>>  {
        const pageSize = AppConfig.settings.pagination.articlesForAny.pageSize;
            return this.repositoryService.getData('banners?pageNo=1&pageSize=' + pageSize).pipe(
                map((data: Observable<ResultMessage<BannerDto[]>> ) => data), catchError((err: HttpErrorResponse) => {
                    this.errorHandlingService.handle(err);
                    return throwError(err);
                  })
            );

    }

}
