import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticlesComponent } from './articles.component';
import { SharedModule } from '../shared/shared.module';
import { ArticlesRoutingModule } from './articles-routing.module';
import { AllArticlesComponent } from './all-articles/all-articles.component';
import { ArticlesCatergoriesComponent } from './articles-catergories/articles-catergories.component';
import { ArticleDetailsComponent } from './article-details/article-details.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ArticlesRoutingModule
  ],
  declarations: [ArticlesComponent, AllArticlesComponent, ArticlesCatergoriesComponent, ArticleDetailsComponent]
})
export class ArticlesModule { }
