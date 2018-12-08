import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';

@Injectable()
export class ArticleCategoriesResolver implements Resolve<Observable<ResultMessage<any>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(): Observable<ResultMessage<any>> {
    return this.repositoryService.getData('articles/categories');
  }
}
