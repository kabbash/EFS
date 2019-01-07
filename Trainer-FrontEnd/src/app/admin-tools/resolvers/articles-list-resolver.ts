import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleListItemDto } from '../../shared/models/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';

@Injectable()
export class AdminArticlesListResolver implements Resolve<Observable<ResultMessage<PagedResult<articleListItemDto>>>> {

  constructor(private repositoryService: RepositoryService) {
  }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<articleListItemDto>>> {
      return  this.repositoryService.getData<PagedResult<articleListItemDto>>('articles/getFilteredData?pageNo=1&pageSize=10&searchText=&status=1');
    }
}