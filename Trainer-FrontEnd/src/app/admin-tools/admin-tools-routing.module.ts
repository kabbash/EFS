import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminToolsComponent } from './admin-tools.component';
import { config } from '../config/pages-config';
import { AddArticleCategoryComponent } from './add-article-category/add-article-category.component';

const routes: Routes = [
  {
    path: '',
    component: AdminToolsComponent
    // children: [
    //   {
    //     path: config.admin.addArticleCategory.name,
    //     component: AddArticleCategoryComponent
    //   }
    // ]
  },
  {
    path: config.admin.addArticleCategory.name,
    component: AddArticleCategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminToolsRoutingModule { }
