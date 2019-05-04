import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../../shared/services/repository.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


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
    private toastr: ToastrService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.contactusForm = this.fb.group({
      'name': ['', [Validators.required, Validators.maxLength(200)]],
      'email': ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      'phoneNumber': ['', [Validators.maxLength(20), Validators.minLength(8), Validators.pattern(/^\d+$/)]],
      'details': ['', [Validators.required, Validators.maxLength(500)]]
    });
  }
  get f() { return this.contactusForm.controls; }

  send() {

    this.submitted = true;
    if (this.contactusForm.invalid) {
      return;
    }

    this.service.create<any>('home/contactus', this.contactusForm.value).subscribe(res => {
      this.toastr.info('تم إرسال الرساله بنجاح، شكرا لتواصلك معنا');
      this.submitted = false;
      this.contactusForm.reset();
    });
  }

}
