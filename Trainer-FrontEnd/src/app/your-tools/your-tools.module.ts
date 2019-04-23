import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { YourToolsComponent } from './your-tools.component';
import { YourToolsRoutingModule } from './your-tools-routing.module';
import { YourToolsCalculatorsComponent } from './calculators/calculators.component';
import { MealsComponent } from './meals/meals.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { YourToolsAllCalculatorsComponent } from './all-calculators/all-calculators.component';

@NgModule({
  imports: [
    SharedModule,
    YourToolsRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    NgxDatatableModule
  ],
  declarations: [YourToolsComponent, YourToolsCalculatorsComponent, MealsComponent, YourToolsAllCalculatorsComponent],
  providers: [
  ]
})
export class YourToolsModule { }
