import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RepositoryService } from '../../shared/services/repository.service';
import { ResultMessage } from '../../shared/models/result-message';
import { Role } from 'src/app/shared/models/users/role.dto';

@Injectable()
export class RolesResolver implements Resolve<Observable<ResultMessage<Role>>> {

    constructor(private repositoryService: RepositoryService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<Role>> {
        return this.repositoryService.getData<Role>('users/getAllRoles');
    }
}