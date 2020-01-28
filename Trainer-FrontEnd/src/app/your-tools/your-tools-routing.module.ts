import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { YourToolsComponent } from './your-tools.component';
import { YourToolsCalculatorsComponent } from './calculators/calculators.component';
import { MealsComponent } from './meals/meals.component';
import { YourToolsAllCalculatorsComponent } from './all-calculators/all-calculators.component';
import { CarbCalcComponent } from './carb-calc/carb-calc.component';
import { ProtienCalcComponent } from './protien-calc/protien-calc.component';
import { FatCalcComponent } from './fat-calc/fat-calc.component';
import { HealthyFatsCalcComponent } from './healthy-fats-calc/healthy-fats-calc.component';
import { PerfectWeightCalcComponent } from './perfect-weight-calc/perfect-weight-calc.component';

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
        path: config.yourTools.carbCalc.name,
        component: CarbCalcComponent
      },
      {
        path: config.yourTools.protienCalc.name,
        component: ProtienCalcComponent
      },
      {
        path: config.yourTools.fatCalc.name,
        component: FatCalcComponent
      },
      {
        path: config.yourTools.healthyFatCalc.name,
        component: HealthyFatsCalcComponent
      },
      {
        path: config.yourTools.perfectWeightCalc.name,
        component: PerfectWeightCalcComponent
      },
      {
        path: config.yourTools.allCalculators.name,
        component: YourToolsAllCalculatorsComponent
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
