import { Component, OnInit } from '@angular/core';
import { config } from '../../config/pages-config';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../auth/services/auth.service';
import { AppService } from '../../app.service';
import { first} from 'rxjs/operators/first';
import {finalize} from 'rxjs/operators/finalize';
import { CustomValidators } from '../Validators/custom-validators';
import { PAGES } from '../../config/defines';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthService,
    private appService: AppService,
    private errorHandlingService: ErrorHandlingService) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', Validators.required ]
    },
      {
        validator: CustomValidators.confirmPassword('password', 'confirmPassword')
      }
      );
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.appService.loading = true;
    this.authenticationService.register(this.registerForm.value)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          this.router.navigate([config.userAccount.accountRegistered.route]);
        }, error => {
          this.errorHandlingService.handle(error, PAGES.AUTHENTICATOIN);
        });
  }
  navigateToLogin() {
    this.router.navigate([config.userAccount.loginPage.route]);
  }
}
