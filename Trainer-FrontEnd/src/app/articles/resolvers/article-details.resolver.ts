import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleDetialsDto } from '../../shared/models/article-details-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';

@Injectable()
export class ArticleDetailsResolver implements Resolve<Observable<ResultMessage<articleDetialsDto>>> {

  constructor(private repositoryService: RepositoryService) {
  }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<articleDetialsDto>> {
      return  this.repositoryService.getData<articleDetialsDto>('articles/' + route.params['articleId']);
    }
}
