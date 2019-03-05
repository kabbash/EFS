import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { YourToolsComponent } from './your-tools.component';
import { YourToolsCalculatorsComponent } from './calculators/calculators.component';
import { MealsComponent } from './meals/meals.component';

const routes: Routes = [
  {
    path: '',
    component: YourToolsComponent,
    children: [
      {
        path: config.yourTools.calculators.name,
        component: YourToolsCalculatorsComponent
      },
      {
        path: config.yourTools.meals.name,
        component: MealsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class YourToolsRoutingModule { }
