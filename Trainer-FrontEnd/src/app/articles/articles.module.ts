import { NgModule } from '@angular/core';
import { ArticlesComponent } from './articles.component';
import { SharedModule } from '../shared/shared.module';
import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesCatergoriesComponent } from './articles-catergories/articles-catergories.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ArticleDetailsComponent } from './article-details/article-details.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { ArticleListResolver } from './resolvers/article-list.resolver';
import { NewsResolver } from './resolvers/articles.news.resolver';
import { ArticlesFoodResolver } from './resolvers/articles.food.resolver';
import { ArticlesChampionshipsResolver } from './resolvers/articles.championships.resolver';

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
    ArticleListResolver,
    NewsResolver,
    ArticlesFoodResolver,
    ArticlesChampionshipsResolver
  ]
})
export class ArticlesModule { }
