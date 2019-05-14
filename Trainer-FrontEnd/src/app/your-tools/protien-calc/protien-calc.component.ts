import { Component, OnInit } from '@angular/core';
import { Calculator } from '../Models/calories-dto';

@Component({
  selector: 'app-protien-calc',
  templateUrl: './protien-calc.component.html',
  styleUrls: ['../calculators/calculators.component.css']
})
export class ProtienCalcComponent implements OnInit {
  calculator = new Calculator();
  constructor() { }

  ngOnInit() {
  }

}
