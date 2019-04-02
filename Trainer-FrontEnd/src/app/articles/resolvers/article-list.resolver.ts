import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { AppConfig } from '../../../config/app.config';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';

@Injectable()
export class ArticleListResolver implements Resolve<Observable<ResultMessage<articleListItemDto[]>>> {

  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<articleListItemDto[]>> {
      const pageSize = AppConfig.settings.pagination.articlesForAny.pageSize;
      return  this.repositoryService.getData<articleListItemDto[]>('articles?pageNo=1&pageSize=' +
      pageSize + '&categoryId=' + route.params['categoryId']).pipe(
        map((data: Observable<ResultMessage<articleListItemDto[]>>) => data) , catchError((error: HttpErrorResponse) => {
          this.errorHandlingService.handle(error, PAGES.ARTICLES);
          return throwError(error);
        })
      );
    }
}
