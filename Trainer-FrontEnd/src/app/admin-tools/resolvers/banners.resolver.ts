import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { BannerDto } from '../../shared/models/banner.dto';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { map } from 'rxjs/internal/operators/map';
import { catchError } from 'rxjs/internal/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable()
export class BannersResolver implements Resolve<ResultMessage<BannerDto[]>>{
    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {

    }
    resolve(): ResultMessage<BannerDto[]> | Observable<ResultMessage<BannerDto[]>> | Promise<ResultMessage<BannerDto[]>>  {
        const pageSize = environment.articlesForAnyPageSize;
            return this.repositoryService.getData('banners?pageNo=1&pageSize=' + pageSize).pipe(
                map((data: Observable<ResultMessage<BannerDto[]>> ) => data), catchError((err: HttpErrorResponse) => {
                    this.errorHandlingService.handle(err);
                    return throwError(err);
                  })
            );

    }

}
