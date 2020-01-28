import { Component, OnInit } from '@angular/core';
import { Calculator } from '../Models/calories-dto';

@Component({
  selector: 'app-carb-calc',
  templateUrl: './carb-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class CarbCalcComponent implements OnInit {
  calculator = new Calculator();
  constructor() { }

  ngOnInit() {
  }

}
