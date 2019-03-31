import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import * as JSONPATH from 'jsonpath';
import { TranslateService } from '@ngx-translate/core';
import { config } from 'src/app/config/pages-config';
import { Router } from '@angular/router';

@Injectable()
export class ErrorHandlingService {

    constructor(private toastrService: ToastrService, private translate: TranslateService, private router: Router) {
    }
    handle(error: any, page?: string) {
        if (!error.error || !error.error.errorCode) {
            this.handleGeneralErrors(error);
        }
        this.getErrorMessage(error, page);
    }
    private getErrorMessage(error, page) {
        const errorKey = error.error && error.error.errorCode ? `${page}.errorCodes.${error.error.errorCode}` :
         `defaultErrorMessage.${error.status}`;
        const errorMessage = this.translate.get(errorKey).subscribe(data => {
            if (data !== errorKey) {
                this.toastrService.error(data);
            }
            this.translate.get('defaultErrorMessages.defaultMessage').subscribe(result => {
                this.toastrService.error(result);
            });
        });
    }
    private handleGeneralErrors(error) {
        if (error.status === '401' || error.status === '403') {
            this.router.navigate([config.home.route]);
        }
    }

}
