import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { productListItemDto } from '../models/products/product-list-item-dto';
import { UtilitiesService } from '../services/utilities.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit, OnChanges {
  @Input() product: productListItemDto = new productListItemDto();
  @Output() rateUpdated: EventEmitter<any> = new EventEmitter();
  baseUrl = environment.filesBaseUrl;
  rate = 0;
  constructor(private utilService: UtilitiesService) { }

  ngOnInit() {
    if (this.product)
      this.rate = this.product.rate;
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['product'].currentValue) {
      this.product.expDate = this.utilService.getDateFormatted(this.product.expDate);
    }
  }

  addRate() {

    setTimeout(() => {
      this.rateUpdated.emit({rate: this.rate, productId: this.product.id});
    }, 100);
  }

}
