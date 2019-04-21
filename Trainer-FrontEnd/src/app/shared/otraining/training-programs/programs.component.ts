import { Component, OnInit, Input } from '@angular/core';
import { OTrainingProgramDto } from '../../../shared/models/otraining/otraining-dto';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-otraining-program',
  templateUrl: './programs.component.html',
  styleUrls: ['./programs.component.scss']
})
export class OTrainingProgramComponent implements OnInit {

  @Input() program: OTrainingProgramDto;
  programFeatures: string[];
  baseurl = environment.filesBaseUrl;
  programProfilePic = '';

  constructor() { }

  ngOnInit() {
    debugger;
    this.programFeatures = this.program.features.split(',');
    this.programProfilePic = this.baseurl + this.program.profilePicture;
  }

}
