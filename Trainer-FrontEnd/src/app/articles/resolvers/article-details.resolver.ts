import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ArticleDetialsDto } from '../../shared/models/article-details-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';

@Injectable()
export class ArticleDetailsResolver implements Resolve<Observable<ResultMessage<ArticleDetialsDto>>> {

  constructor(private repositoryService: RepositoryService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<ArticleDetialsDto>> {
    if (route.params['articleId'] != 0)
      return this.repositoryService.getData<ArticleDetialsDto>('articles/' + route.params['articleId']);
    else
      return null;
  }
}
