import { Injectable, NgZone } from '@angular/core';
import { map } from 'rxjs/operators';
import { Roles } from '../models/roles.enum';
import { User } from '../models/user';
import { RepositoryService } from '../../shared/services/repository.service';
import { apiUrl } from '../../../config/api.config';
import { ResultMessage } from '../../shared/models/result-message';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs/internal/observable/of';
import { Router } from '@angular/router';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { AuthenticationErrorsCode } from '../../user-account/models/authentication-error-code.enum';
import { config } from '../../config/pages-config';
import { PAGES } from '../../config/defines';
import { first } from 'rxjs/internal/operators/first';
import { finalize } from 'rxjs/internal/operators/finalize';
import { AppService } from 'src/app/app.service';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public fbLoginSubject = new Subject<any>();
  constructor(private repositoryService: RepositoryService, private http: HttpClient,
  private router: Router, private errorHandlingService: ErrorHandlingService,
  private appService: AppService, private ngZone: NgZone) { }

  login(userName: string, password: string) {
    return this.repositoryService.create<User>(apiUrl.userAccount.login, { userName, password })
      .pipe(map(result => this.setUserToken(result)));
  }

  loginWithFb(FB, returnUrl) {
   
        
    FB.login((res) => {
      FB.api('/me', {fields: 'name,email'}, (response) => {
        this.repositoryService.post<User>('authentication/loginFb', response).subscribe(result => {
          this.setUserToken(result);
          if (result.status == 200)
            this.fbLoginSubject.next();
  
        }, error => {
          if (error.error.errorCode == AuthenticationErrorsCode.EmailNotConfirmed)
            this.router.navigate([config.userAccount.emailNotConfirmed.route]);
          else
            this.errorHandlingService.handle(error, PAGES.AUTHENTICATOIN);
        });
      });
    }, {scope: 'public_profile'});
    
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
