import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { BannerDto } from '../../shared/models/banner.dto';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { ManageBannerService } from '../services/manage-banner.service';
import { ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';
import { UtilitiesService } from '../../shared/services/utilities.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Sanitizer } from '@angular/core';
import { SafeHtml } from '@angular/platform-browser';
import { SecurityContext } from '@angular/core';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { AppService } from '../../app.service';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';
import { ImageCropperComponent } from '../../shared/image-cropper/image-cropper.component';

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
  @ViewChild('cropper') cropperModal: ImageCropperComponent;
  imageEvent;
  isSubmitted = false;
  constructor(private fb: FormBuilder, private bannerService: ManageBannerService,
     private util: UtilitiesService,
    private route: ActivatedRoute,
    private sanitizer: Sanitizer,
    private router: Router,
    private appService: AppService,
    private errorHandlingService: ErrorHandlingService) { }

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

  onFileSelect(event, isCropped?) {
    this.imageEvent = isCropped ? null : event;
    const file = isCropped ? event : event.target.files[0];
    this.banner.imageFile = file;
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.addedImageUrl = e.target.result;
    };
    reader.readAsDataURL(file);
  }

  submit() {
    this.isSubmitted = true;
    this.appService.loading = true;
    if (this.bannerForm.invalid) {
      alert('invalid data');
      this.appService.loading = false;
      return;
    }
    this.prepareData();
    const formData = new FormData();
    this.util.appendFormData(formData, this.banner);
    this.bannerService.add(formData).subscribe(data => {
      this.router.navigate([config.admin.manageBanners.route]);
      this.appService.loading = false;
    } , error => {
      this.errorHandlingService.handle(error, PAGES.BANNER);
      this.appService.loading = false;
    });
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
  cropClicked() {
    this.cropperModal.open();
  }
}
