import { Component, OnInit } from '@angular/core';
import { calroiesCalc } from '../Models/calories-dto';


@Component({
  selector: 'app-your-tools-calculators-catergories',
  templateUrl: './calculators.component.html',
  styleUrls: ['./calculators.component.css']
})
export class YourToolsCalculatorsComponent implements OnInit {

  caloriesObj = new calroiesCalc();

  constructor() { }

  ngOnInit() {
  }
}
