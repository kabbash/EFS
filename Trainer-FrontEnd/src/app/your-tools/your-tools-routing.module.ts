import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { YourToolsComponent } from './your-tools.component';
import { YourToolsCalculatorsComponent } from './landing/landing.component';

const routes: Routes = [
  {
    path: '',
    component: YourToolsComponent,
    children: [
      {
        path: config.yourTools.calculators.name,
        component: YourToolsCalculatorsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class YourToolsRoutingModule { }
