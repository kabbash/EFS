import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';

import { ContactusFormComponent } from './contact-us-form/contact-us-form.component';
import { ContactusComponent } from './contactus.component';
import { BioComponent } from './bio/bio.component';

const routes: Routes = [
  {
    path: '',
    component: ContactusComponent,
    children: [
      {
        path: config.contactus.form.name,
        component: ContactusFormComponent
      },
      {
        path: config.contactus.bio.name,
        component: BioComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactusRoutingModule { }
