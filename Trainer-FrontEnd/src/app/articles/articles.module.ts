import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticlesComponent } from './articles.component';
import { SharedModule } from '../shared/shared.module';
import { ArticlesRoutingModule } from './articles-routing.module';
import { AllArticlesComponent } from './all-articles/all-articles.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ArticlesRoutingModule
  ],
  declarations: [ArticlesComponent, AllArticlesComponent]
})
export class ArticlesModule { }
