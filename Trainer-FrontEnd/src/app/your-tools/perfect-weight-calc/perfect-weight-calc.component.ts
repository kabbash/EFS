import { Component, OnInit } from '@angular/core';
import { Calculator } from '../Models/calories-dto';

@Component({
  selector: 'app-perfect-weight-calc',
  templateUrl: './perfect-weight-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class PerfectWeightCalcComponent implements OnInit {
  calculator = new Calculator();
  constructor() { }

  ngOnInit() {
  }

}
