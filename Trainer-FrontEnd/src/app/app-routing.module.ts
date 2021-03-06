import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from './config/pages-config';
import { NotfoundComponent } from './shared/notfound/notfound.component';
import { BannersResolver } from './admin-tools/resolvers/banners.resolver';

const routes: Routes = [
  {
    path: 'test',
    loadChildren: './test/test.module#TestModule'
  },
  {
    path: 'home',
    loadChildren: './home/home.module#HomeModule',
    resolve: {banners: BannersResolver}
  },
  {
    path: config.articles.route,
    loadChildren: './articles/articles.module#ArticlesModule',
  },
  {
    path: config.userAccount.route,
    loadChildren: './user-account/user-account.module#UserAccountModule',
  },
  {
    path: config.products.route,
    loadChildren: './products/products.module#ProductsModule',
  },
  {
    path: config.demos.route,
    loadChildren: './demos/demos.module#DemosModule',
  },
  {
    path: config.admin.name,
    loadChildren: './admin-tools/admin-tools.module#AdminToolsModule'
  },
  {
    path: config.yourTools.name,
    loadChildren: './your-tools/your-tools.module#YourToolsModule'
  },
  {
    path: config.contactus.name,
    loadChildren: './contactus/contactus.module#ContactusModule'
  },
  {
    path: config.writers.name,
    loadChildren: './writers/writers.module#WritersModule'
  },
  {
    path: config.onlinetraining.name,
    loadChildren: './online-training/online-training.module#OnlineTrainingModule'
  },
  {
    path: config.users.name,
    loadChildren: './users/users.module#UsersModule'
  },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
