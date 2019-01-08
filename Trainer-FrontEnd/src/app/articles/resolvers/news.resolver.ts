import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { articleListItemDto } from '../../shared/models/article-list-item-dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { PredefinedCategories } from '../../shared/models/predefined-categories.enum';

@Injectable()
export class NewsResolver implements Resolve<Observable<ResultMessage<articleListItemDto[]>>> {

  constructor(private repositoryService: RepositoryService) {
  }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<articleListItemDto[]>> {
      return  this.repositoryService.getData<articleListItemDto[]>('articles/getbycategory/'+ PredefinedCategories.news);
    }
}
