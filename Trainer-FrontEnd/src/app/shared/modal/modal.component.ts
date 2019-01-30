import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { productListItemDto } from '../models/product-list-item-dto';
import { UtilitiesService } from '../services/utilities.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit, OnChanges {
  productImages = [];
  @Input() product: productListItemDto = new productListItemDto();

  constructor(private utilService: UtilitiesService) { }

  ngOnInit() {
    this.productImages = ['/assets/images/test/whey.png',
      'http://ec2-54-188-217-195.us-west-2.compute.amazonaws.com:4400//Files/Products/1010/2.png'
      , 'http://ec2-54-188-217-195.us-west-2.compute.amazonaws.com:4400//Files/Products/1010/3.png'];
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['product'].currentValue) {
      this.product.expDate = this.utilService.getDateFormatted(this.product.expDate);
    }
  }

}
