import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterComponent } from './register/register.component';
import { UserAccountComponent } from './user-account.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ConfirmEmailResolver } from './resolvers/confirm-email.resolver';
import { EmailNotConfirmedComponent } from './email-not-confirmed/email-not-confirmed.component';
import { AccountRegisteredComponent } from './account-registered/account-registered.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SetResetedPasswordComponent } from './set-reseted-password/set-reseted-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AuthGuard } from '../auth/guards/auth.guard';

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
      },
      {
        path: config.userAccount.confirmEmail.name,
        component: ConfirmEmailComponent,
        resolve: { user: ConfirmEmailResolver }
      },
      {
        path: config.userAccount.emailNotConfirmed.name,
        component: EmailNotConfirmedComponent
      },
      {
        path: config.userAccount.accountRegistered.name,
        component: AccountRegisteredComponent
      },
      {
        path: config.userAccount.resetPassword.name,
        component: ResetPasswordComponent
      },
      {
        path: config.userAccount.setResetedPassword.name,
        component: SetResetedPasswordComponent
      },
      {
        path: config.userAccount.changePassword.name,
        component: ChangePasswordComponent,
        canActivate: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserAccountRoutingModule { }
