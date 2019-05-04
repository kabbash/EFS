import { Component, OnInit } from '@angular/core';
import { calroiesCalc } from '../Models/calories-dto';

@Component({
  selector: 'app-fat-calc',
  templateUrl: './fat-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class FatCalcComponent implements OnInit {
  caloriesObj = new calroiesCalc();
  constructor() { }

  ngOnInit() {
  }

}
