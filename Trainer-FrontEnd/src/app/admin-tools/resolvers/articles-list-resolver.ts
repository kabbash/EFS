import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { AppConfig } from '../../../config/app.config';
import { map } from 'rxjs/internal/operators/map';
import { catchError } from 'rxjs/internal/operators/catchError';
import { articleCategoryDto } from 'src/app/shared/models/articles/article-category-dto';
import { HttpErrorResponse } from '@angular/common/http/src/response';
import { ErrorHandlingService } from 'src/app/shared/services/error-handling.service';
import { PAGES } from 'src/app/config/defines';

@Injectable()
export class AdminArticlesListResolver implements Resolve<Observable<ResultMessage<PagedResult<articleListItemDto>>>> {

  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<articleListItemDto>>> {
    const pageSize = AppConfig.settings.pagination.articlesForAdmin.pageSize;
    return this.repositoryService.getData<PagedResult<articleListItemDto>>('articles/getforadmin?pageNo=1&pageSize=' + pageSize).pipe(
      map((data: Observable<ResultMessage<PagedResult<articleCategoryDto>>>) => data), catchError((error: HttpErrorResponse) => {
        this.errorHandlingService.handle(error);
        return null;
      })
    );
  }
}
