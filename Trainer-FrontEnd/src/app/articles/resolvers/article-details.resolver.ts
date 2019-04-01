import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { ArticleDetialsDto } from '../../shared/models/articles/article-details-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';

@Injectable()
export class ArticleDetailsResolver implements Resolve<Observable<ResultMessage<ArticleDetialsDto>>> {

  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<ArticleDetialsDto>> {
    if (route.params['articleId'] !== 0) {
      return this.repositoryService.getData<ArticleDetialsDto>('articles/' + route.params['articleId']).pipe(
        map((data: Observable<ResultMessage<ArticleDetialsDto>>) => data) , catchError((error: HttpErrorResponse) => {
          this.errorHandlingService.handle(error, PAGES.ARTICLES);
          return throwError(error);
        })
      );
    } else {
      return null;

    }
  }
}
