import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { NgbModule, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../app/shared/shared.module';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { AuthModule } from './auth/auth.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AuthService } from './auth/services/auth.service';
import { ItemReviewResolver } from './admin-tools/resolvers/item-review.resolver';
import { AuthGuard } from './auth/guards/auth.guard';
import { NgbUTCStringAdapter } from './shared/services/ngb-string.adapter';
import { AppConfig } from '../config/app.config';
import { BannersResolver } from './admin-tools/resolvers/banners.resolver';
import { TrainingResolver } from './admin-tools/resolvers/training-resolver';
export function CreateTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
}
export function initializeApp(appConfig: AppConfig) {
  return () => appConfig.load();
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'Trainer-FrontEnd' }),
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    AuthModule.forRoot(),
    NgbModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (CreateTranslateLoader),
        deps: [HttpClient]

      }
    }),
    AngularFontAwesomeModule
  ],
  providers: [
    AuthService,
    ItemReviewResolver,
    AuthGuard,
    { provide: NgbDateAdapter, useClass: NgbUTCStringAdapter },
    AppConfig,
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [AppConfig], multi: true
    },
    BannersResolver
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
