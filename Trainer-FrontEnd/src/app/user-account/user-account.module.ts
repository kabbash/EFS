import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAccountRoutingModule } from './user-account-routing.module';
import { UserAccountComponent } from './user-account.component';

@NgModule({
  imports: [
    CommonModule,
    UserAccountRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [ LoginPageComponent, RegisterComponent, UserAccountComponent]
})
export class UserAccountModule { }
