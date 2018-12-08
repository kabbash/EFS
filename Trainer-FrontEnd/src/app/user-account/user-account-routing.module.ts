import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterComponent } from './register/register.component';
import { UserAccountComponent } from './user-account.component';

const routes: Routes = [
  {
    path: '',
    component: UserAccountComponent,
    children: [
      {
        path: config.userAccount.loginPage.name,
        component: LoginPageComponent
      },
      {
        path: config.userAccount.register.name,
        component: RegisterComponent
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAccountRoutingModule { }
