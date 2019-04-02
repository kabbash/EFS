import { Component, OnInit } from '@angular/core';
import { config } from '../../config/pages-config';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth/services/auth.service';
import { AppService } from '../../app.service';
import { first} from 'rxjs/operators/first';
import {finalize} from 'rxjs/operators/finalize';
import { PAGES } from '../../config/defines';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  resetForm: FormGroup;
  submitted = false;
  mailSent = false;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private authenticationService: AuthService,
    private appService: AppService,
    private errorHandlingService: ErrorHandlingService
  ) { }

  ngOnInit() {
    this.resetForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.resetForm.controls; }

  navigateToLogin() {
    this.router.navigate([config.userAccount.loginPage.route]);
  }

  onSubmit() {
    this.submitted = true;
    this.mailSent = false;

    // stop here if form is invalid
    if (this.resetForm.invalid) {
      return;
    }
    this.appService.loading = true;
    this.authenticationService.resetPassword(this.resetForm.value)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          this.mailSent = true;
        }, error => {
          this.errorHandlingService.handle(error, PAGES.AUTHENTICATOIN);
        });
  }

}
