import { NgModule } from '@angular/core';

import { AdminToolsRoutingModule } from './admin-tools-routing.module';
import { PendingApprovalArticlesResolver } from './resolvers/pending-approval-articles-resolver';
import { AdminToolsComponent } from './admin-tools.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ManageCategoriesComponent } from './manage-categories/manage-categories.component';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { PendingApprovalArticlesComponent } from './articles/pending-approval-articles/pending-approval-articles.component';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';

@NgModule({
  imports: [
    AdminToolsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations:
  [
    AddCategoryComponent,
    AdminToolsComponent,
    ManageCategoriesComponent,
    ManageProductsCategoriesComponent,
    ManageArticlesCategoriesComponent,
    PendingApprovalArticlesComponent,
    ManageArticlesComponent],

  providers: [
    PendingApprovalArticlesResolver
  ]
})
export class AdminToolsModule { }
