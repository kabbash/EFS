import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { WritersComponent } from './writers.component';
import { ManageArticlesComponent } from './manage-article/manage-articles.component';
import { WritersArticlesListComponent } from './articles-list/writers-articles-list.component';
import { WritersArticlesListResolver } from './resolvers/writers-articles-list-resolver';
import { WritersArticleDetailsResolver } from './resolvers/writers-article-details-resolver';


const routes: Routes = [
    {
        path: '',
        component: WritersComponent,
        children: [
            {
                path: config.writers.manageArticle.name,
                component: ManageArticlesComponent,
                resolve: { articleDetails: WritersArticleDetailsResolver }
            },
            {
                path: config.writers.articleslist.name,
                component: WritersArticlesListComponent,   
                resolve: { articlesList: WritersArticlesListResolver }
            }
        ]
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class WritersRoutingModule { }
