import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Roles } from '../models/roles.enum';
import { User } from '../models/user';
import { RepositoryService } from '../../shared/services/repository.service';
import { apiUrl } from '../../../config/api.config';
import { ResultMessage } from '../../shared/models/result-message';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private repositoryService: RepositoryService) { }

  login(userName: string, password: string) {
    return this.repositoryService.create<User>(apiUrl.userAccount.login, { userName, password })
      .pipe(map(result => this.setUserToken(result)));
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('currentUser') != null;
  }

  isAdmin(): boolean {
    return this.isInRole(Roles.Admin);
  }

  isArticlesWriter(): boolean {
    return this.isInRole(Roles.ArticleWriter);
  }

  isInRole(role: Roles): boolean {
    return this.isLoggedIn() && this.getUserInfo().roles.some((item => item == role));
  }

  getUserInfo(): User {
    return this.isLoggedIn() ? JSON.parse(localStorage.getItem('currentUser')) as User : null;
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

  register(user) {
    return this.repositoryService.create<User>(apiUrl.userAccount.register, user);
  }

  verifyEmail(activationToken: string) {
    return this.repositoryService.getData<User>(apiUrl.userAccount.verifyEmail + "?activationToken=" + activationToken)
      .pipe(map(result => this.setUserToken(result)));
  }

  resetPassword(username: string) {
    return this.repositoryService.create(apiUrl.userAccount.resetPassword, username);
  }

  setResetedPassword(data) {
    return this.repositoryService.create<User>(apiUrl.userAccount.setResetedPassword, data)
      .pipe(map(result => this.setUserToken(result)));
  }

  changgePassword(data) {
    return this.repositoryService.create<User>(apiUrl.userAccount.changePassword, data)
      .pipe(map(result => this.setUserToken(result)));
  }

  private setUserToken(result: ResultMessage<User>) {
    if (result.status === 200) {
      const user = result.data;
      // login successful if there's a jwt token in the response
      if (user && user.token) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
      }
    }
    return result;
  }
}
