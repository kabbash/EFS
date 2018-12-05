import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { config } from '../../config/pages-config';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  navigateToRegister() {
    this.router.navigate([config.login.register.route]);
  }

}
