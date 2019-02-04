import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PredefinedCategories } from '../../shared/models/articles/articles-predefined-categories.enum';
import { AppConfig } from '../../../config/app.config';

@Injectable()
export class ArticlesFoodResolver implements Resolve<Observable<ResultMessage<articleListItemDto[]>>> {

  constructor(private repositoryService: RepositoryService) {
  }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<articleListItemDto[]>> {
      let pageSize = AppConfig.settings.pagination.articlesForAny.pageSize;
      return  this.repositoryService.getData<articleListItemDto[]>('articles?pageNo=1&pageSize='+ pageSize + '&categoryId='+ PredefinedCategories.food);
    }
}
 