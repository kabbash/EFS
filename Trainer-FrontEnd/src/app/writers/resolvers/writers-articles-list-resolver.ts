import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { AppConfig } from '../../../config/app.config';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class WritersArticlesListResolver implements Resolve<Observable<ResultMessage<PagedResult<articleListItemDto>>>> {

  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<articleListItemDto>>> {
    const pageSize = AppConfig.settings.pagination.articlesForAdmin.pageSize;
    return this.repositoryService.getData<PagedResult<articleListItemDto>>('articles/getforwriters?pageNo=1&pageSize=' + pageSize).pipe(
      map(data => data), catchError(error => {
        this.errorHandlingService.handle(error);
        return throwError(error);
      })
    );
  }
}
