import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminToolsComponent } from './admin-tools.component';
import { config } from '../config/pages-config';
import { AddArticleCategoryComponent } from './add-article-category/add-article-category.component';
import { ManageArticlesCategoriesComponent } from './manage-articles-categories/manage-articles-categories.component';
import { ArticleCategoriesResolver } from '../shared/resolvers/article-categories.resolver';

const routes: Routes = [
  {
    path: '',
    component: AdminToolsComponent
  },
  {
    path: config.admin.addArticleCategory.name,
    component: AddArticleCategoryComponent
  },
  {
    path: config.admin.manageArticlesCategories.name,
    component: ManageArticlesCategoriesComponent,
    resolve: {categories: ArticleCategoriesResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminToolsRoutingModule { }
