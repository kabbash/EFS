import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticlesComponent } from './articles.component';
import { SharedModule } from '../shared/shared.module';
import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesCatergoriesComponent } from './articles-catergories/articles-catergories.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ArticleDetailsComponent } from './article-details/article-details.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleCategoriesResolver } from './resolvers/article-categories.resolver';
import { ArticleDetailsResolver } from './resolvers/article-details.resolver';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ArticlesRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [ArticlesComponent, ArticlesListComponent, ArticlesCatergoriesComponent, ArticleDetailsComponent],
  providers: [
    ArticleCategoriesResolver,
    ArticleDetailsResolver
  ]
})
export class ArticlesModule { }
