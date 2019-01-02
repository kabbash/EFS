import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth/services/auth.service';
import { AppService } from 'src/app/app.service';
import { finalize, first } from 'rxjs/operators';

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
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.resetPasswordForm = this.formBuilder.group({
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]]
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
        });
  }
}