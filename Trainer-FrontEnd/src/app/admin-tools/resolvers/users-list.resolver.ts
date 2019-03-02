import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResultMessage } from '../../shared/models/result-message';
import { PagedResult } from '../../shared/models/paged-result';
import { AppConfig } from '../../../config/app.config';
import { User } from 'src/app/auth/models/user';
import { UsersService } from '../services/users.service';

@Injectable()
export class UsersListResolver implements Resolve<Observable<ResultMessage<PagedResult<User>>>> {

    constructor(private service: UsersService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<ResultMessage<PagedResult<User>>> {
        let pageSize = AppConfig.settings.pagination.usersForAdmin.pageSize;
        return this.service.getFilteredUsers('users/getfiltered?pageNo=1&pageSize=' + pageSize);
    }
}