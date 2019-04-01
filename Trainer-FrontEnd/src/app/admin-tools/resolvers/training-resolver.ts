import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { BannerDto } from '../../shared/models/banner.dto';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { catchError, map } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class TrainingResolver implements Resolve<ResultMessage<BannerDto[]>>{

    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(): ResultMessage<BannerDto[]> | Observable<ResultMessage<BannerDto[]>> | Promise<ResultMessage<BannerDto[]>> {
        return this.repositoryService.getData('banners').pipe(
            map((data: Observable<ResultMessage<BannerDto[]>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            }));
    }
}
