import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminToolsRoutingModule } from './admin-tools-routing.module';
import { AddArticleCategoryComponent } from './add-article-category/add-article-category.component';
import { AdminToolsComponent } from './admin-tools.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    AdminToolsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [AddArticleCategoryComponent, AdminToolsComponent]
})
export class AdminToolsModule { }
