import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { articleCategoryDto } from '../../shared/models/article-category-dto';
import { ResultMessage } from 'src/app/shared/models/result-message';
import { Observable } from 'rxjs';

@Injectable()
export class ArticleCategoriesResolver implements Resolve<Observable<ResultMessage<any>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(): Observable<ResultMessage<any>> {
    return this.repositoryService.getData('articles/categories');
  }
}
