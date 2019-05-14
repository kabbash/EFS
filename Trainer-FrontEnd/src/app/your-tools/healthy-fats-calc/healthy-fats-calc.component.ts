import { Component, OnInit } from '@angular/core';
import { Calculator } from '../Models/calories-dto';

@Component({
  selector: 'app-healthy-fats-calc',
  templateUrl: './healthy-fats-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class HealthyFatsCalcComponent implements OnInit {
  calculator = new Calculator();
  constructor() { }

  ngOnInit() {
  }

}
