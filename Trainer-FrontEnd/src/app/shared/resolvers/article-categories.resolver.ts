import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../models/result-message';
import { RepositoryService } from '../services/repository.service';
@Injectable()
export class ArticleCategoriesResolver implements Resolve<Observable<ResultMessage<any>>> {
  constructor(private repositoryService: RepositoryService) {
  }
  resolve(): Observable<ResultMessage<any>> {
    return this.repositoryService.getData('articles/categories');
  }
}
