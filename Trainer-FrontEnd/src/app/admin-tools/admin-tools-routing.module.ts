import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminToolsComponent } from './admin-tools.component';
import { config } from '../config/pages-config';
import { AddArticleCategoryComponent } from './articles/add-article-category/add-article-category.component';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { ArticleCategoriesResolver } from '../shared/resolvers/article-categories.resolver';
import { PendingApprovalArticlesComponent } from './articles/pending-approval-articles/pending-approval-articles.component';
import { PendingApprovalArticlesResolver } from './resolvers/pending-approval-articles-resolver';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';
import { ArticleDetailsResolver } from '../articles/resolvers/article-details.resolver';

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
    resolve: { categories: ArticleCategoriesResolver }
  },
  {
    path: config.admin.manageArticles.name,
    component: ManageArticlesComponent,
    resolve: {articleDetails: ArticleDetailsResolver}
  },
  {
    path: config.admin.pendingApprovalArticles.name,
    component: PendingApprovalArticlesComponent,
    resolve: { articlesList: PendingApprovalArticlesResolver }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminToolsRoutingModule { }
