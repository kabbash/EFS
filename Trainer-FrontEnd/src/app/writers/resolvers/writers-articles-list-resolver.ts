import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { map, catchError } from 'rxjs/operators';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class WritersArticlesListResolver implements Resolve<Observable<ResultMessage<PagedResult<articleListItemDto>>>> {

  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<articleListItemDto>>> {
    const pageSize = environment.articlesForAdminPageSize;
    return this.repositoryService.getData<PagedResult<articleListItemDto>>('articles/getforwriters?pageNo=1&pageSize=' + pageSize).pipe(
      map(data => data), catchError(error => {
        this.errorHandlingService.handle(error);
        return throwError(error);
      })
    );
  }
}
