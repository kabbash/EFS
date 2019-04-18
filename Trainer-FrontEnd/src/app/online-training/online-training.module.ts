import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { OnlineTrainingComponent } from './online-training.component';
import { OnlineTrainingRoutingModule } from './online-training-routing.module';
import { PackagesComponent } from './training-packages/packages.component';

@NgModule({
  imports: [
    SharedModule,
    OnlineTrainingRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [OnlineTrainingComponent, PackagesComponent],
  providers: [
  ]
})
export class OnlineTrainingModule { }
