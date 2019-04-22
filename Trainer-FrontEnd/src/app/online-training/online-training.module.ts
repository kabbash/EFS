

import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { OnlineTrainingComponent } from './online-training.component';
import { OnlineTrainingRoutingModule } from './online-training-routing.module';
import { OTrainingResolver } from './resolvers/otraining.resolver';
@NgModule({
  imports: [ 
    SharedModule,
    OnlineTrainingRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule, 
  ],
  declarations: [OnlineTrainingComponent],
  providers: [OTrainingResolver]
})
export class OnlineTrainingModule {
}
