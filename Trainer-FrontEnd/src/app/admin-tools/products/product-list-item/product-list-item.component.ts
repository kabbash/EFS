import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { productListItemDto } from 'src/app/shared/models/product-list-item-dto';
import { UtilitiesService } from 'src/app/shared/services/utilities.service';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.css']
})
export class ProductListItemComponent implements OnInit, OnChanges {
   @Input() public product: productListItemDto 
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
