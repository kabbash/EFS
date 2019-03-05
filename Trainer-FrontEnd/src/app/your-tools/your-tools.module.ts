import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { YourToolsComponent } from './your-tools.component';
import { YourToolsRoutingModule } from './your-tools-routing.module';
import { YourToolsCalculatorsComponent } from './calculators/calculators.component';
import { MealsComponent } from './meals/meals.component';

@NgModule({
  imports: [
    SharedModule,
    YourToolsRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [YourToolsComponent, YourToolsCalculatorsComponent, MealsComponent],
  providers: [
  ]
})
export class YourToolsModule { }
