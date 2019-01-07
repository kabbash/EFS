import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { config } from '../../config/pages-config';
import { Roles } from '../models/roles.enum';

@Injectable({
  providedIn: 'root'
})
export class TrainerGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.authService.isLoggedIn()) {
      // not logged in so redirect to login page with the return url
      this.router.navigate([config.userAccount.loginPage.route], { queryParams: { returnUrl: state.url } });
      return false;

    }
    if (!this.authService.isInRole(Roles.Trainer)) { 
      // not trainer so redirect to not authorized 
      this.router.navigate([config.notfound.route], { queryParams: { returnUrl: state.url } });
      return false;
    }
    // logged in and trainer so return true
    return true;
  }
}
