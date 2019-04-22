import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OnlineTrainingComponent } from './online-training.component';
import { OTrainingResolver } from './resolvers/otraining.resolver';

const routes: Routes = [
  {
    path: '',
    component: OnlineTrainingComponent,    
    resolve: { resultObj: OTrainingResolver }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OnlineTrainingRoutingModule { }
