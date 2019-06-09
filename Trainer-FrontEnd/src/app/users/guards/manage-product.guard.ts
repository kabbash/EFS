import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
import { config } from '../../config/pages-config';
@Injectable()
export class ManageProductGuard implements CanActivate {
    constructor(private authenticationService: AuthService, private toastr: ToastrService,
         private translate: TranslateService, private router: Router) {}
    canActivate(): boolean  {
        if (this.authenticationService.isLoggedIn()) {
            return true;
        } else {
            this.translate.get('manageUsers.loginFirst').subscribe(data => {
                this.toastr.info(data);
            });
            this.router.navigate([config.userAccount.loginPage.route]);
            return false;
        }

    }
}
