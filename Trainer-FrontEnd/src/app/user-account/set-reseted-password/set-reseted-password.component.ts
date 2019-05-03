import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { finalize, first } from 'rxjs/operators';
import { AuthService } from '../../auth/services/auth.service';
import { AppService } from '../../app.service';
import { PAGES } from '../../config/defines';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { CustomValidators } from '../Validators/custom-validators';

@Component({
  selector: 'app-set-reseted-password',
  templateUrl: './set-reseted-password.component.html',
  styleUrls: ['./set-reseted-password.component.css']
})
export class SetResetedPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup;
  submitted = false;
  activationToken: string;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthService,
    private appService: AppService,
    private route: ActivatedRoute,
    private errorHandlingService: ErrorHandlingService) { }

  ngOnInit() {
    this.resetPasswordForm = this.formBuilder.group({
      password: ['', [Validators.required,Validators.maxLength(16) , Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required]]
    },
    {
      validator: CustomValidators.confirmPassword('password', 'confirmPassword')
    });
    this.route.queryParams.subscribe(params => this.activationToken = params.activationToken || "")
  }

  // convenience getter for easy access to form fields
  get f() { return this.resetPasswordForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.resetPasswordForm.invalid) {
      return;
    }
    this.appService.loading = true;
    this.authenticationService.setResetedPassword({
      activationToken: this.activationToken,
      newPassword: this.f.password.value
    })
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          this.router.navigate(['/']);
        }, error => {
          this.errorHandlingService.handle(error, PAGES.AUTHENTICATOIN);
        });
  }
}
