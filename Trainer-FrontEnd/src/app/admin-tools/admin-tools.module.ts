import { NgModule } from '@angular/core';

import { AdminToolsRoutingModule } from './admin-tools-routing.module';
import { AdminArticlesListResolver } from './resolvers/articles-list-resolver';
import { AdminToolsComponent } from './admin-tools.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ManageCategoriesComponent } from './manage-categories/manage-categories.component';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';
import { AddItemForReviewComponent } from './add-item-for-review/add-item-for-review.component';
import { ArticlesListComponent } from './articles/articles-list/articles-list.component';
import { ArticleDetailsEditmodeComponent } from '../shared/article-details-editmode/article-details-editmode.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AdminArticlesService } from './services/admin.articles.services';


@NgModule({
  imports: [
    AdminToolsRoutingModule,
    SharedModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),   
  ],
  declarations:
  [
    AddCategoryComponent,
    AdminToolsComponent,
    ManageCategoriesComponent,
    ManageProductsCategoriesComponent,
    ManageArticlesCategoriesComponent,
    ManageArticlesComponent,
    AddItemForReviewComponent,
    ArticlesListComponent,
    ArticleDetailsEditmodeComponent
  ],

  providers: [
    AdminArticlesListResolver,
    AdminArticlesService
  ]
})
export class AdminToolsModule { }
