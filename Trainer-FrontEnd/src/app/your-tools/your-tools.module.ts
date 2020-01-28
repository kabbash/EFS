import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { YourToolsComponent } from './your-tools.component';
import { YourToolsRoutingModule } from './your-tools-routing.module';
import { YourToolsCalculatorsComponent } from './calculators/calculators.component';
import { MealsComponent } from './meals/meals.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { YourToolsAllCalculatorsComponent } from './all-calculators/all-calculators.component';
import { FatCalcComponent } from './fat-calc/fat-calc.component';
import { PerfectWeightCalcComponent } from './perfect-weight-calc/perfect-weight-calc.component';
import { ProtienCalcComponent } from './protien-calc/protien-calc.component';
import { CarbCalcComponent } from './carb-calc/carb-calc.component';
import { HealthyFatsCalcComponent } from './healthy-fats-calc/healthy-fats-calc.component';

@NgModule({
  imports: [
    SharedModule,
    YourToolsRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    NgxDatatableModule
  ],
  declarations: [YourToolsComponent, YourToolsCalculatorsComponent, MealsComponent, YourToolsAllCalculatorsComponent, FatCalcComponent, PerfectWeightCalcComponent, ProtienCalcComponent, CarbCalcComponent, HealthyFatsCalcComponent],
  providers: [
  ]
})
export class YourToolsModule { }
