import { Component, OnInit, Input } from '@angular/core';
import { productListItemDto } from '../../shared/models/product-list-item-dto';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() product: productListItemDto;
  constructor() { }

  ngOnInit() {
  }

}
