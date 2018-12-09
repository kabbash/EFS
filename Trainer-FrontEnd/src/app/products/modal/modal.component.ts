import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
import { UtilitiesService } from '../../shared/services/utilities.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit, OnChanges {

  @Input() product: productListItemDto = new productListItemDto();
  constructor(private utilService: UtilitiesService) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['product'].currentValue) {
      this.product.expDate = this.utilService.getDateFormatted(this.product.expDate);
      this.product.prodDate = this.utilService.getDateFormatted(this.product.prodDate);
      this.product.rate = 4;
    }
  }

}
