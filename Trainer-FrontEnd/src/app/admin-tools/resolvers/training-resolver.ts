import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { ResultMessage } from "../../shared/models/result-message";
import { Observable } from "rxjs";
import { RepositoryService } from "../../shared/services/repository.service";
import { OTrainingDto } from "../../shared/models/otraining/otraining-dto";

@Injectable()
export class TrainingResolver implements Resolve<ResultMessage<OTrainingDto[]>>{
   
    constructor(private repositoryService: RepositoryService) {
        
    }
    resolve(): ResultMessage<OTrainingDto[]> | Observable<ResultMessage<OTrainingDto[]>> | Promise<ResultMessage<OTrainingDto[]>> {
        return this.repositoryService.getData('OTraining');
    }
}