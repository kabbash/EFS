import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../../shared/services/repository.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-contactus-form-catergories',
  templateUrl: './contact-us-form.component.html',
  styleUrls: ['./contact-us-form.component.css']
})
export class ContactusFormComponent implements OnInit {

  contactusForm: any;
  submitted = false;
  constructor(private service: RepositoryService,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.contactusForm = this.fb.group({
      'name': ['', Validators.required],
      'email': ['', [Validators.required, Validators.email]],
      'phoneNumber': [],
      'details': ['', Validators.required]
    });
  }
  get f() { return this.contactusForm.controls; }

  send() {

    this.submitted = true;
    if (this.contactusForm.invalid) {
      return;
    }

    this.service.create<any>('home/contactus', this.contactusForm.value).subscribe(res=> {
      alert('تمت العمليه بنجاح، شكرا لتواصلك معنا');      
      this.submitted = false;
      this.contactusForm.reset();
    });
  }

}
