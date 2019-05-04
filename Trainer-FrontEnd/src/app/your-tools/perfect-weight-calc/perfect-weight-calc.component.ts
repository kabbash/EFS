import { Component, OnInit } from '@angular/core';
import { calroiesCalc } from '../Models/calories-dto';

@Component({
  selector: 'app-perfect-weight-calc',
  templateUrl: './perfect-weight-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class PerfectWeightCalcComponent implements OnInit {
  caloriesObj = new calroiesCalc();
  constructor() { }

  ngOnInit() {
  }

}
