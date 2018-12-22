import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminToolsComponent } from './admin-tools.component';
import { config } from '../config/pages-config';
import { AddArticleCategoryComponent } from './add-article-category/add-article-category.component';
import { ArticleCategoriesResolver } from '../shared/resolvers/article-categories.resolver';
import { ManageCategoriesComponent } from './manage-categories/manage-categories.component';
import { ManageArticlesCategoriesComponent } from './manage-articles-categories/manage-articles-categories.component';
import { ProductsCategoriesResolver } from '../products/resolvers/products-categories.resolver';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';

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
  },
  {
    path: config.admin.manageProductsCategories.name,
    component: ManageProductsCategoriesComponent,
    resolve: {categories: ProductsCategoriesResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminToolsRoutingModule { }
