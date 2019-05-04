import { Component, OnInit } from '@angular/core';
import { calroiesCalc } from '../Models/calories-dto';

@Component({
  selector: 'app-protien-calc',
  templateUrl: './protien-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class ProtienCalcComponent implements OnInit {
  caloriesObj = new calroiesCalc();
  constructor() { }

  ngOnInit() {
  }

}
