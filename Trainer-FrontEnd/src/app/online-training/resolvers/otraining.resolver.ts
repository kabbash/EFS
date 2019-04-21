import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { Injectable } from '@angular/core';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';
import { OTrainingDto } from '../../shared/models/otraining/otraining-dto';

@Injectable()
export class OTrainingResolver implements Resolve<Observable<ResultMessage<OTrainingDto[]>>> {
  constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
  }
  resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<OTrainingDto[]>> {
      debugger;
    return this.repositoryService.getData<OTrainingDto[]>('OTraining').pipe(
      map((data:  Observable<ResultMessage<OTrainingDto[]>>) => data), catchError((error: HttpErrorResponse) => {
        this.errorHandlingService.handle(error, PAGES.OTRAINING);
        return throwError(error);
      })
    );
  }
}
