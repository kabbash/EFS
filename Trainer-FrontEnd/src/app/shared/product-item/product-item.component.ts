import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() cardName: string;
  @Input() cardImage: string;
  @Input() price: string;
  currentRate = 8;

  constructor() { }

  ngOnInit() {
  }

}
