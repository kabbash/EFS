import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { OnlineTrainingComponent } from './online-training.component';
import { OnlineTrainingRoutingModule } from './online-training-routing.module';

@NgModule({
  imports: [
    SharedModule,
    OnlineTrainingRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [OnlineTrainingComponent],
  providers: [
  ]
})
export class OnlineTrainingModule { }
