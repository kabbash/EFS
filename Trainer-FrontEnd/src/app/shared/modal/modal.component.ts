import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
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
  baseUrl = environment.filesBaseUrl;
  constructor(private utilService: UtilitiesService) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['product'].currentValue) {
      this.product.expDate = this.utilService.getDateFormatted(this.product.expDate);
    }
  }

}
