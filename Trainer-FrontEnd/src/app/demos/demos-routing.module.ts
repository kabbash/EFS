import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { DemosComponent } from './demos.component';
import { AllDemosComponent } from './all-demos/all-demos.component';
import { FormsComponent } from './forms/forms.component';
import { DropdownsComponent } from './dropdowns/dropdowns.component';

const routes: Routes = [
  {
    path: '',
    component: DemosComponent,
    children: [
      {
        path: config.demos.allDemos.name,
        component: AllDemosComponent
      },
      {
        path: config.demos.forms.name,
        component: FormsComponent
      },
      {
        path: config.demos.dropdowns.name,
        component: DropdownsComponent
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DemosRoutingModules { }
