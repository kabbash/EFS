import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from './config/pages-config';
import { NotfoundComponent } from './shared/notfound/notfound.component';
import { ArticlesComponent } from './articles/articles.component';

const routes: Routes = [
  {
    path: '',
    component: ArticlesComponent,
  },
  {
    path: 'test',
    loadChildren: './test/test.module#TestModule'
  },
  { path: '404', component: NotfoundComponent },
  { path: '**', redirectTo: '/404' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
