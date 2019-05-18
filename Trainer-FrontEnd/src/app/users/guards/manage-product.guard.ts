import { CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';
@Injectable()
export class ManageProductGuard implements CanActivate {
    constructor(private authenticationService: AuthService, private toastr: ToastrService, private translate: TranslateService) {}
    canActivate(): boolean  {
        if (this.authenticationService.isLoggedIn()) {
            return true;
        } else {
            this.translate.get('').subscribe(data => {
                this.toastr.info(data);
            });
            return false;
        }

    }
}
