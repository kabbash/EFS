import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { WritersArticlesListComponent } from './articles-list/writers-articles-list.component';
import { WritersArticlesListResolver } from './resolvers/writers-articles-list-resolver';
import { WritersArticleDetailsResolver } from './resolvers/writers-article-details-resolver';
import { WritersComponent } from './writers.component';
import { ManageArticlesComponent } from './manage-article/manage-articles.component';
import { WritersRoutingModule } from './writers-routing.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    WritersRoutingModule
  ],
  declarations: [
    WritersArticlesListComponent,
    WritersComponent,
    ManageArticlesComponent
  ],
  providers: [
    WritersArticlesListResolver,
    WritersArticleDetailsResolver,
  ]
})
export class WritersModule { }
