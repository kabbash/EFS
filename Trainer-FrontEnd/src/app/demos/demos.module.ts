import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemosComponent } from './demos.component';
import { AllDemosComponent } from './all-demos/all-demos.component';
import { FormsComponent } from './forms/forms.component';
import { DropdownsComponent } from './dropdowns/dropdowns.component';
import { DemosRoutingModules } from './demos-routing.module';
import { SharedModule } from '../shared/shared.module';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
@NgModule({
  imports: [
    CommonModule,
    DemosRoutingModules,
    SharedModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
  ],
  declarations: [DemosComponent, AllDemosComponent, FormsComponent, DropdownsComponent]
})
export class DemosModule { }
