import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { AppConfig } from '../../../config/app.config';

@Injectable()
export class AdminArticlesListResolver implements Resolve<Observable<ResultMessage<PagedResult<articleListItemDto>>>> {

  constructor(private repositoryService: RepositoryService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<articleListItemDto>>> {
    let pageSize = AppConfig.settings.pagination.articlesForAdmin.pageSize;
    return this.repositoryService.getData<PagedResult<articleListItemDto>>('articles/getforadmin?pageNo=1&pageSize=' + pageSize);
  }
}
