
import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { ResultMessage } from '../../shared/models/result-message';
import { OTrainingDto } from "../../shared/models/otraining/otraining-dto";
import { Observable, throwError } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { map} from 'rxjs/operators/map';
import {catchError} from 'rxjs/operators/catchError';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Injectable()
export class TrainingResolver implements Resolve<ResultMessage<OTrainingDto[]>>{

    constructor(private repositoryService: RepositoryService, private errorHandlingService: ErrorHandlingService) {
    }
    resolve(): ResultMessage<OTrainingDto[]> | Observable<ResultMessage<OTrainingDto[]>> | Promise<ResultMessage<OTrainingDto[]>> {
        return this.repositoryService.getData('OTraining').pipe(
            map((data: Observable<ResultMessage<OTrainingDto[]>>) => data), catchError((error: HttpErrorResponse) => {
                this.errorHandlingService.handle(error);
                return throwError(error);
            }));
    }
}
