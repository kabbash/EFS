import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { first, finalize } from 'rxjs/operators';
import { CustomValidators } from '../Validators/custom-validators';
import { AuthService } from '../../auth/services/auth.service';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  changePasswordForm: FormGroup;
  submitted = false;
  changed = false;

  constructor(private formBuilder: FormBuilder,
    private authenticationService: AuthService,
    private appService: AppService) { }

  ngOnInit() {
    this.changePasswordForm = this.formBuilder.group({
      oldPassword: ['', [Validators.required]],
      newPassword: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
    },
      {
        Validator: CustomValidators.confirmPassword('newPassword', 'confirmPassword')
      });

  }

  // convenience getter for easy access to form fields
  get f() { return this.changePasswordForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.changed = false;
    // stop here if form is invalid
    if (this.changePasswordForm.invalid) {
      return;
    }
    this.appService.loading = true;
    this.authenticationService.changgePassword(this.changePasswordForm.value)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          this.changed = true;
        });
  }

}
