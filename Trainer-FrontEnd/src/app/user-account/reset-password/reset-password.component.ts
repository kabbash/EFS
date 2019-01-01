import { Component, OnInit } from '@angular/core';
import { config } from '../../config/pages-config';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth/services/auth.service';
import { AppService } from '../../app.service';
import { first, finalize } from 'rxjs/operators';

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
    private appService: AppService
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
        });
  }

}
