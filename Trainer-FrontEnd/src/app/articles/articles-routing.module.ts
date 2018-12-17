import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticlesComponent } from './articles.component';
import { config } from '../config/pages-config';
import { ArticlesCatergoriesComponent } from './articles-catergories/articles-catergories.component';
import { ArticleDetailsComponent } from './article-details/article-details.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleDetailsResolver } from './resolvers/article-details.resolver';
import { ArticleListResolver } from './resolvers/article-list.resolver';
import { ArticleCategoriesResolver } from '../shared/resolvers/article-categories.resolver';

const routes: Routes = [
  {
    path: '',
    component: ArticlesComponent,
    children: [
      {
        path: config.articles.articlesList.name,
        component: ArticlesListComponent,
        resolve: {articleList: ArticleListResolver}
      },
      {
        path: config.articles.articlesCategories.name,
        component: ArticlesCatergoriesComponent,
        resolve: {categories: ArticleCategoriesResolver}
      },
      {
        path: config.articles.articleDetails.name,
        component: ArticleDetailsComponent,
        resolve: {details: ArticleDetailsResolver}
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArticlesRoutingModule { }
