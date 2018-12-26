import { NgModule } from '@angular/core';

import { AdminToolsRoutingModule } from './admin-tools-routing.module';
import { AddArticleCategoryComponent } from './articles/add-article-category/add-article-category.component';
import { AdminToolsComponent } from './admin-tools.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { PendingApprovalArticlesComponent } from './articles/pending-approval-articles/pending-approval-articles.component';
import { PendingApprovalArticlesResolver } from './resolvers/pending-approval-articles-resolver';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';

@NgModule({
  imports: [
    AdminToolsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [AddArticleCategoryComponent, AdminToolsComponent, ManageArticlesCategoriesComponent, PendingApprovalArticlesComponent , ManageArticlesComponent],
  providers: [
    PendingApprovalArticlesResolver
  ]
})
export class AdminToolsModule { }
