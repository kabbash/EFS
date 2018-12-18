import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { config } from '../../config/pages-config';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../auth/services/auth.service';
import { first } from 'rxjs/operators';
import { AppService } from '../../app.service';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  form: FormGroup;
  returnUrl: any;
  error: any;
  submitted = false;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private authenticationService: AuthService,
    private appService: AppService) {
    
  }

  ngOnInit() {
    this.form = this.fb.group(
      {
        "userName": ['',  [Validators.required, Validators.email]],
        "password": ['', Validators.required]
      }
    );
    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  navigateToRegister() {
    this.router.navigate([config.userAccount.register.route]);
  }

  onSubmit() {
    
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.appService.loading = true;
    this.authenticationService.login(this.form.value.userName, this.form.value.password)
      .pipe(first())
      .subscribe(result => {
        if (result.status == 200)
          this.router.navigate([this.returnUrl]);
        this.appService.loading = false;
      });
  }
}
