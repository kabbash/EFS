import { NgModule } from '@angular/core';

import { AdminToolsRoutingModule } from './admin-tools-routing.module';
import { AddArticleCategoryComponent } from './add-article-category/add-article-category.component';
import { AdminToolsComponent } from './admin-tools.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ManageCategoriesComponent } from './manage-categories/manage-categories.component';
import { ManageArticlesCategoriesComponent } from './manage-articles-categories/manage-articles-categories.component';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';

@NgModule({
  imports: [
    AdminToolsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations:
  [
    AddArticleCategoryComponent,
    AdminToolsComponent,
    ManageCategoriesComponent,
    ManageArticlesCategoriesComponent,
    ManageProductsCategoriesComponent],
  providers: [
  ]
})
export class AdminToolsModule { }
