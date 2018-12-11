import { Injectable } from '@angular/core';

import { map } from 'rxjs/operators';
import { RepositoryService } from '../../shared/services/repository.service';
import { apiUrl } from '../../../config/api.config';
import { User } from '../models/user';

@Injectable()
export class AuthService {

  constructor(private repositoryService: RepositoryService) { }

  login(userName: string, password: string) {
    return this.repositoryService.create<User>(apiUrl.userAccount.login, { userName, password }).pipe(map(result => {
      if (result.status == 200) {
        let user = result.data;
        // login successful if there's a jwt token in the response
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
        }
      }
      return result;
    }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

  register(user) {
    return this.repositoryService.create<User>(apiUrl.userAccount.register, user);
  }
}
