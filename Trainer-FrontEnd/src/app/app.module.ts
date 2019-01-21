import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbPaginationModule, NgbAlertModule, NgbRating } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../app/shared/shared.module';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ArticlesModule } from './articles/articles.module';
import { DemosModule } from './demos/demos.module';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { HomeModule } from './home/home.module';
import { ProductsModule } from './products/products.module';
import { AuthModule } from './auth/auth.module';
import { UserAccountModule } from './user-account/user-account.module';
import { LoginModule } from './login/login.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AuthService } from './auth/services/auth.service';
import { ItemReviewResolver } from './admin-tools/resolvers/item-review.resolver';
import { AuthGuard } from './auth/guards/auth.guard';

export function CreateTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, 'assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'trainer' }),
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
    AuthGuard
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
