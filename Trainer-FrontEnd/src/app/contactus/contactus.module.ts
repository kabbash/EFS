import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ContactusComponent } from './contactus.component';
import { ContactusFormComponent } from './contact-us-form/contact-us-form.component';
import { ContactusRoutingModule } from './contactus-routing.module';

@NgModule({
  imports: [
    SharedModule,
    ContactusRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [ContactusComponent, ContactusFormComponent],
  providers: [
  ]
})
export class ContactusModule { }
