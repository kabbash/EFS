import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticlesComponent } from './articles.component';
import { config } from '../config/pages-config';
import { AllArticlesComponent } from './all-articles/all-articles.component';

const routes: Routes = [
  {
    path: '',
    component: ArticlesComponent,
    children: [
      {
        path: config.articles.allArticles.route,
        component: AllArticlesComponent
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArticlesRoutingModule { }
