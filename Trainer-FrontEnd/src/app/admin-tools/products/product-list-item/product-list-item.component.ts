import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { productListItemDto } from '../../../shared/models/products/product-list-item-dto';
import { environment } from '../../../../environments/environment';
import { UtilitiesService } from '../../../shared/services/utilities.service';


@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.css']
})
export class ProductListItemComponent implements OnInit, OnChanges {
   @Input() public product: productListItemDto;
   baseurl = environment.filesBaseUrl;

  constructor(private utilService: UtilitiesService) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['product'].currentValue) {
      this.product.expDate = this.utilService.getDateFormatted(this.product.expDate);
    }
  }
}
