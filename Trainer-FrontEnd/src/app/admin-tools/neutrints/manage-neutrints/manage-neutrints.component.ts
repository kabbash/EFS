import { Component, OnInit } from '@angular/core';
import { FoodItem } from '../../../shared/models/neutrints/food-item-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../../app.service';
import { config } from '../../../config/pages-config';
import { UtilitiesService } from '../../../shared/services/utilities.service';
import { NeutrintsService } from '../../../shared/services/neutrints.service';
import { first} from 'rxjs/operators/first';
import {finalize} from 'rxjs/operators/finalize';

@Component({
  selector: 'app-manage-neutrints',
  templateUrl: './manage-neutrints.component.html',
  styleUrls: ['./manage-neutrints.component.css']
})
export class ManageNeutrintsComponent implements OnInit {
  itemId: number;
  item: FoodItem;
  isNew: boolean;

  constructor(private route: ActivatedRoute, private router: Router, private appService: AppService, private service: NeutrintsService, private util: UtilitiesService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.itemId = params['foodItemId'];
      if (this.itemId > 0) {
        this.route.data.subscribe(result => {
          this.item = result.foodItem.data;
          this.isNew = false;
          this.appService.loading = false;
        });
      }
      else {
        this.item = new FoodItem();
        this.isNew = true;
      }
    });
  }
  cancel() {
    this.router.navigate([config.admin.neutrintsList.route]);
  }

  submit() {
    const formData = new FormData();

    this.util.appendFormData(formData, this.item);
    (this.isNew ? this.service.add(formData) : this.service.update(this.itemId, formData))
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          if (data.status === 200) {
            this.item = data.data;
            alert("تم تعديل المنتج بنجاح");
            this.router.navigate([config.admin.neutrintsList.route]);
          }
        });
  }
}
