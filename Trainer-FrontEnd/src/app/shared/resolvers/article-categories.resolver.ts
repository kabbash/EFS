import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../models/result-message';
import { RepositoryService } from '../services/repository.service';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../services/error-handling.service';
@Injectable()
export class ArticleCategoriesResolver implements Resolve<Observable<ResultMessage<any>>> {
  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(): Observable<ResultMessage<any>> {
    return this.repositoryService.getData('articles/categories').pipe(
      map((data: Observable<ResultMessage<any>>) => data) , catchError((error: HttpErrorResponse) => {
        this.errorHandlingService.handle(error);
        return null;
      })
    );
  }
}
