import { Component, OnInit } from '@angular/core';
import { Calculator } from '../Models/calories-dto';


@Component({
  selector: 'app-your-tools-calculators-catergories',
  templateUrl: './calculators.component.html',
  styleUrls: ['./calculators.component.css']
})
export class YourToolsCalculatorsComponent implements OnInit {

  calculator = new Calculator();

  constructor() { }

  ngOnInit() {
  }
}
