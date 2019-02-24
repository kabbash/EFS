import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { BannerDto } from 'src/app/shared/models/banner.dto';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { ManageBannerService } from 'src/app/admin-tools/services/manage-banner.service';
import { ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';
import { UtilitiesService } from 'src/app/shared/services/utilities.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Sanitizer } from '@angular/core';
import { SafeHtml } from '@angular/platform-browser/src/security/dom_sanitization_service';
import { SecurityContext } from '@angular/core';
import { environment } from 'src/environments/environment';
import { config } from 'src/app/config/pages-config';

@Component({
  selector: 'app-add-banner',
  templateUrl: './add-banner.component.html',
  styleUrls: ['./add-banner.component.css'],
})
export class AddBannerComponent implements OnInit {

  @Input() banner: BannerDto = new BannerDto();
  bannerForm: FormGroup;
  addedImageUrl: string;
  buttonAlign: string;
  buttonColor: string;
  titleAlign: string;
  isAdd = true;
  editTitleHTML: SafeHtml;
  editButtonHTML: SafeHtml;
  baseurl = environment.filesBaseUrl;
  @ViewChild("titleHtml") titleHtml: ElementRef;
  @ViewChild("buttonHtml") buttonHtml: ElementRef;
  isSubmitted = false;
  constructor(private fb: FormBuilder, private bannerService: ManageBannerService,
     private util: UtilitiesService,
    private route: ActivatedRoute,
    private sanitizer: Sanitizer,
    private router: Router) { }

  ngOnInit() {
    this.bannerForm = this.fb.group({
      'title': ['', Validators.required],
      'buttonText': ['',  Validators.required],
      'imageFile': [null, Validators.required],
      'buttonUrl': ['', Validators.required]
    }); 
    this.buttonAlign = 'center';
    this.buttonColor = 'blue';
    this.titleAlign = 'center';
  }

  onFileSelect(file) {
    this.banner.imageFile = file;
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.addedImageUrl = e.target.result;
    };
    reader.readAsDataURL(file);
  }

  submit() {
    this.isSubmitted = true;
    if (this.bannerForm.invalid) {
      alert('invalid data');
      return;
    }
    this.prepareData();
    const formData = new FormData();
    this.util.appendFormData(formData, this.banner);
    this.bannerService.add(formData).subscribe(data => {
      alert('success');
      this.router.navigate([config.admin.manageBanners.route]);
    } ,error => {
      alert(error)
    })
  }
  prepareData() {
    this.banner.title = this.titleHtml.nativeElement.innerHTML;
    this.banner.buttonText = this.buttonHtml.nativeElement.innerHTML;
    this.banner.buttonUrl = this.bannerForm.controls['buttonUrl'].value;
  }
  reset() {
    this.banner = new BannerDto();
    this.isSubmitted = false;
  }
}
