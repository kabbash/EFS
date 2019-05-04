import { Component, OnInit } from '@angular/core';
import { calroiesCalc } from '../Models/calories-dto';

@Component({
  selector: 'app-healthy-fats-calc',
  templateUrl: './healthy-fats-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class HealthyFatsCalcComponent implements OnInit {
  caloriesObj = new calroiesCalc();
  constructor() { }

  ngOnInit() {
  }

}
