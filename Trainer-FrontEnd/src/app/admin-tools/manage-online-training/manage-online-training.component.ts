import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { OTrainingDetailsDto, OTrainingProgramDto } from '../../shared/models/otraining/otraining-dto';
import { AppService } from '../../app.service';
import { UtilitiesService } from '../../shared/services/utilities.service';
import { config } from '../../config/pages-config';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-manage-online-training',
  templateUrl: './manage-online-training.component.html',
  styleUrls: ['./manage-online-training.component.css']
})
export class ManageOnlineTrainingComponent implements OnInit {

  onlinetrainingForm: any;
  submitted = false;
  onlineTrainingDetails = new OTrainingDetailsDto();
  onlineTrainingPrograms: OTrainingProgramDto[];

  constructor(private route: ActivatedRoute,
    private service: RepositoryService,
    private router: Router,
    private util: UtilitiesService,
    private appService: AppService,
    private toastrService: ToastrService,
    private fb: FormBuilder) { }

  ngOnInit() {

    this.route.data.subscribe(result => {

      this.onlineTrainingDetails = result.trainingInfo.data.detailsDto;
      this.onlineTrainingPrograms = result.trainingInfo.data.programsDto;
      this.appService.loading = false;
    });

    this.onlinetrainingForm = this.fb.group({
      'description': ['', Validators.required],
      'forJoin': ['', Validators.required]
    });
  }
  get f() { return this.onlinetrainingForm.controls; }

  update() {

    this.submitted = true;
    if (this.onlinetrainingForm.invalid) {
      return;
    }

    const formData = new FormData();
    this.util.appendFormData(formData, this.onlineTrainingDetails);
    this.appService.loading = true;
    this.service.update("otraining/updatedetails", formData).subscribe(
      () => {
        this.toastrService.info('تم تعديل بيانات التدريب الاونلاين');
        this.appService.loading = false;
        this.submitted = false;
      }, error => {
        this.toastrService.error(error);
        this.appService.loading = false;
      }
    );
  }

  addProgram(){
    this.router.navigate([config.admin.managePrograms.route, 0]);
  }
}
