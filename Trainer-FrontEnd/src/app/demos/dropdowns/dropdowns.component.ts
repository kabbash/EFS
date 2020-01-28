import { Component, OnInit } from '@angular/core';
import { NgbDropdownConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dropdowns',
  templateUrl: './dropdowns.component.html',
  styleUrls: ['./dropdowns.component.css']
})
export class DropdownsComponent implements OnInit {

  constructor(config: NgbDropdownConfig) {
    config.placement = 'top-left';
    config.autoClose = false;
  }

  ngOnInit() {
  }



}
