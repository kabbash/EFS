import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { OTrainingDetailsDto, OTrainingProgramDto } from '../../shared/models/otraining/otraining-dto';
import { AppService } from '../../app.service';
import { UtilitiesService } from '../../shared/services/utilities.service';
import { config } from '../../config/pages-config';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';


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
    private toastr: ToastrService,
    private translate: TranslateService,
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
        this.toastr.info('تم تعديل بيانات التدريب الاونلاين');
        this.appService.loading = false;
        this.submitted = false;
      }, error => {
        this.toastr.error(error);
        this.appService.loading = false;
      }
    );
  }
  addProgram(){
    this.router.navigate([config.admin.managePrograms.route, 0]);
  }  
  editProgram(programId) {
    this.router.navigate([config.admin.managePrograms.route,programId]);
  }
  deleteProgram(programId) {
    event.stopPropagation();

    this.translate.get('programForm.messages').subscribe(data => {
      const confirmed =  confirm(data.confirmDelete);
      if (confirmed) {
        this.appService.loading = true;
        this.service.delete('OTraining/' + programId).subscribe(() => {
          this.appService.loading = false;
          this.onlineTrainingPrograms = this.onlineTrainingPrograms.filter(c=>c.id != programId);
          this.toastr.info(data.success);
        }, error => {
          this.appService.loading = false;
          this.toastr.error(error);
        });
      }  
    });    
  }
}
