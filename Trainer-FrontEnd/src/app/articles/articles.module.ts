import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticlesComponent } from './articles.component';
import { SharedModule } from '../shared/shared.module';
import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesCatergoriesComponent } from './articles-catergories/articles-catergories.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ArticleDetailsComponent } from './article-details/article-details.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleDetailsResolver } from './resolvers/article-details.resolver';
import { ArticleListResolver } from './resolvers/article-list.resolver';
import { ArticlesService } from './articles.service';
import { NewsResolver } from './resolvers/news.resolver';

@NgModule({
  imports: [
    SharedModule,
    ArticlesRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [ArticlesComponent, ArticlesListComponent, ArticlesCatergoriesComponent, ArticleDetailsComponent],
  providers: [
    ArticleDetailsResolver,
    ArticleListResolver,
    ArticlesService,
    NewsResolver
  ]
})
export class ArticlesModule { }
