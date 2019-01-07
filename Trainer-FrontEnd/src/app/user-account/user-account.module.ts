import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAccountRoutingModule } from './user-account-routing.module';
import { UserAccountComponent } from './user-account.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ConfirmEmailResolver } from './resolvers/confirm-email.resolver';
import { EmailNotConfirmedComponent } from './email-not-confirmed/email-not-confirmed.component';
import { AccountRegisteredComponent } from './account-registered/account-registered.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SetResetedPasswordComponent } from './set-reseted-password/set-reseted-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

@NgModule({
  imports: [
    CommonModule,
    UserAccountRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    LoginPageComponent,
    RegisterComponent,
    UserAccountComponent,
    ConfirmEmailComponent,
    EmailNotConfirmedComponent,
    AccountRegisteredComponent,
    ResetPasswordComponent,
    SetResetedPasswordComponent,
    ChangePasswordComponent
  ],
  providers: [
    ConfirmEmailResolver
  ]
})
export class UserAccountModule { }
