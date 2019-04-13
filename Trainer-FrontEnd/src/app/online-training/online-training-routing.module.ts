import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { OnlineTrainingComponent } from './online-training.component';

const routes: Routes = [
  {
    path: '',
    component: OnlineTrainingComponent,
    children: [
      {
        path: config.contactus.form.name,
        component: OnlineTrainingComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OnlineTrainingRoutingModule { }
