import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../app/shared/shared.module';
import { ArticlesModule } from './articles/articles.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'trainer' }),
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    ArticlesModule
  ],
  providers: [],
  exports: [
    SharedModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
