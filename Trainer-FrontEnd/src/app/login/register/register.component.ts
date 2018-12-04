import { Component, OnInit } from '@angular/core';
import { config } from 'src/app/config/pages-config';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  navigateToLogin() {
    this.router.navigate([config.login.loginPage.route]);
  }
}
