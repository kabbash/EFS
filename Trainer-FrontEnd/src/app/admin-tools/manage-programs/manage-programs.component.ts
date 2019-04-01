import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { OTrainingProgramDto } from '../../shared/models/otraining/otraining-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../app.service';
import { RepositoryService } from '../../shared/services/repository.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ImageCropperComponent } from '../../shared/image-cropper/image-cropper.component';
import { config } from '../../config/pages-config';

@Component({
  selector: 'app-manage-programs',
  templateUrl: './manage-programs.component.html',
  styleUrls: ['./manage-programs.component.css']
})
export class ManageProgramsComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private reposatoryService: RepositoryService,
    private router: Router,
    private route: ActivatedRoute,
    private appService: AppService,
    private translate: TranslateService) {
      this.route.params.subscribe(params => {
        this.programId = params['programId'];
      });
     }

  programForm: FormGroup;
  imageUrl: string;
  program: OTrainingProgramDto = new OTrainingProgramDto();
  addedImageUrl: string;
  successMessage: string;
  imageEvent;
  programId :number;
  @ViewChild('cropper') cropper: ImageCropperComponent;

  ngOnInit() {

    if (this.programId > 0) {
      this.route.data.subscribe(result => {
        this.program = result.programDetails.data;
        this.appService.loading = false;        
      });

    } else {
      this.program = new OTrainingProgramDto();
    }

    this.programForm = this.fb.group({
      'name': ['', Validators.required],
      'features' : ['', Validators.required],
      'profilePictureFile': [null, !this.program.profilePicture ? Validators.required : null]
    });
  }

  submit() {
    this.programForm.controls['profilePictureFile'].markAsTouched();
    this.programForm.controls['name'].markAsTouched();
    this.programForm.controls['features'].markAsTouched();

    this.appService.loading = true;
    
    if (this.programForm.valid) {
      if (this.programId > 0) {
        this.updateProgram();
      } else {
        this.addProgram();
      }
    } else {
      this.appService.loading = false;      
      return;
    }
  }
  addProgram() {
    this.reposatoryService.create('OTraining/AddProgram', this.prepareData(this.programForm.value)).subscribe(data => {
      
      alert('تم اضافة البرنامج بنجاح');
      this.navigateToListing();
    }, error => {
      this.appService.loading = false;
      alert(error);
    });
  }
  updateProgram() {
    this.reposatoryService.update('otraining/updateprogram/' + this.programId , this.prepareData(this.programForm.value)).subscribe(
      () => {
        alert('تم تعديل البرنامج');
        this.navigateToListing();

      }, error => {
        this.appService.loading = false;
        alert(error);
      }
    );
  }
  prepareData(categoryData) {
    const formData = new FormData();
    formData.append('name', categoryData.name);
    formData.append('features', categoryData.features);
    formData.append('profilePictureFile', categoryData.profilePictureFile);
    formData.append('profilePicture', categoryData.profilePicture ? categoryData.profilePicture : '');
    debugger;
    return formData;
  }

  onFileSelect(event, isCropped) {
    debugger;
    this.imageEvent = isCropped ? null : event;
    const file = isCropped ? event : event.target.files[0]
    this.program.profilePictureFile = file;
    this.programForm.controls['profilePictureFile'].setValue(file)
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.addedImageUrl = e.target.result;
    };
    reader.readAsDataURL(file);
  }

  navigateToListing() {
      this.router.navigate([config.admin.onlineTraining.route]);
  }
  openCropper() {
    this.cropper.open();
  }
}