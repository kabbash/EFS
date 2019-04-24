import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../app.service';
import { OTrainingDto } from '../shared/models/otraining/otraining-dto';

@Component({
  selector: 'app-online-training',
  templateUrl: './online-training.component.html',
  styleUrls: ['./online-training.component.scss']
})
export class OnlineTrainingComponent implements OnInit {

  otrainingModel: OTrainingDto;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private appSrevice: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(response => {
      this.otrainingModel = response.resultObj.data;
      this.appSrevice.loading = false;
    });
  }
  

}
