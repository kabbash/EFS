import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { LoginComponent } from './login.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
    // children: [
    //   {
    //     path: config.login.loginPage.name,
    //     component: LoginPageComponent
    //   },
    //   {
    //     path: config.login.register.name,
    //     component: RegisterComponent
    //   }

    // ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
