import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';

import { ContactusFormComponent } from './contact-us-form/contact-us-form.component';
import { ContactusComponent } from './contactus.component';

const routes: Routes = [
  {
    path: '',
    component: ContactusComponent,
    children: [
      {
        path: config.contactus.form.name,
        component: ContactusFormComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactusRoutingModule { }
