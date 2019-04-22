import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { OTrainingProgramDto } from '../../../shared/models/otraining/otraining-dto';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-otraining-program',
  templateUrl: './programs.component.html',
  styleUrls: ['./programs.component.scss']
})
export class OTrainingProgramComponent implements OnInit {

  @Input() program: OTrainingProgramDto;
  @Input() localImageUrl: string;
  @Input() showActionBtns: boolean = false;
  @Output() editClicked: EventEmitter<any> = new EventEmitter();
  @Output() deleteClicked: EventEmitter<any> = new EventEmitter();

  programFeatures: string[];
  baseurl = environment.filesBaseUrl;
  programProfilePic = '';

  constructor() { }

  ngOnInit() {
    this.programProfilePic = this.baseurl + this.program.profilePicture;
  }

  deleteProgram() {
    this.deleteClicked.emit(this.program.id);
  }
  editProgram() {
    this.editClicked.emit(this.program.id);
  }
}
