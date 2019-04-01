import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { RepositoryService } from '../../shared/services/repository.service';
@Injectable()
export class ProgramDetailsResolver implements Resolve<Observable<ResultMessage<any>>> {
    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ResultMessage<any>> {
        return route.params.programId > 0 ? this.repositoryService.getData('OTraining/getprogram/' + route.params.programId) : null;
    }
}
