import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { ArticleDetialsDto } from '../../shared/models/articles/article-details-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class WritersArticleDetailsResolver implements Resolve<Observable<ResultMessage<ArticleDetialsDto>>> {

  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<ArticleDetialsDto>> {
    if (route.params['articleId'] !== 0) {
     return this.repositoryService.getData<ArticleDetialsDto>('articles/' + route.params['articleId']).pipe(
       map((data) => data), catchError(error => {
         this.errorHandlingService.handle(error);
        return throwError(error);
       })
     );
    } else {
      return null;

    }
  }
}
