import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import * as JSONPATH from 'jsonpath';
import { TranslateService } from '@ngx-translate/core';
import { config } from 'src/app/config/pages-config';
import { Router } from '@angular/router';
import { AppService } from 'src/app/app.service';

@Injectable()
export class ErrorHandlingService {

    constructor(private toastrService: ToastrService, private translate: TranslateService, private router: Router,
         private appService: AppService) {
    }
    handle(error: any, page?: string) {
        this.handleErrorStatus(error);
        this.handleError(error, page);
        this.appService.loading = false;
    }
    private handleError(error, page) {
        if (error.error && error.error.validationMessages && error.error.validationMessages.length > 0) {
            return this.handleValidationErrorMessages(error, page);
        }

        return this.handleBackEndErrorCode(error, page);
    }
    private handleErrorStatus(error) {
        if (error.status === 401 || error.status === 403) {
            this.router.navigate([config.home.route]);
        }
    }

    private handleValidationErrorMessages(error, page) {
        error.error.validationMessages.forEach(validationError => {
            const errorKey = `${page}.${validationError}`;
            this.getErrorMessage(errorKey);
        });
    }

    private handleBackEndErrorCode(error, page) {
        const errorKey = error.error && error.error.errorCode ? `${page}.errorCodes.${error.error.errorCode}` :
        `defaultErrorMessages.${error.status}`;
       this.getErrorMessage(errorKey);
    }

    private getErrorMessage(errorKey) {
        this.translate.get(errorKey).subscribe(data => {
            if (data !== errorKey) {
                this.toastrService.error(data);
                return;
            }
            this.translate.get('defaultErrorMessages.defaultMessage').subscribe(result => {
                this.toastrService.error(result);
                return;
            });
        });
    }

}
