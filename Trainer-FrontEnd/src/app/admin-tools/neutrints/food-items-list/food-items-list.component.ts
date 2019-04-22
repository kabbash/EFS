
import { Component, OnInit } from '@angular/core';
import { FoodItem } from '../../../shared/models/neutrints/food-item-dto';
import { PagerDto } from '../../../shared/models/pager.dto';
import { FoodIemFilter } from '../../../shared/models/neutrints/food-item-filter';
import { NeutrintsService } from '../../../shared/services/neutrints.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../../app.service';
import { AppConfig } from '../../../../config/app.config';
import { config } from '../../../config/pages-config';
import { first, finalize } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-food-items-list',
  templateUrl: './food-items-list.component.html',
  styleUrls: ['./food-items-list.component.css']
})
export class FoodItemsListComponent implements OnInit {
  foodItemsList: FoodItem[];
  pagerDto = new PagerDto();
  filter = new FoodIemFilter();

  constructor(private route: ActivatedRoute, private toastrService: ToastrService, private service: NeutrintsService, 
    public appService: AppService, private router: Router) { }

  ngOnInit() {
    this.pagerDto.pageSize = this.filter.pageSize = AppConfig.settings.pagination.neutrintsForAdmin.pageSize;
    this.route.data.subscribe(result => {
      this.pagerDto = result.foodItemsList.data;
      this.foodItemsList = result.foodItemsList.data.results;
    });
  }
  getData() {
    this.appService.loading = true;
    var searchText = this.filter.searchText != undefined && this.filter.searchText != null && this.filter.searchText != "" ? "&searchText=" + this.filter.searchText.trim() : "";
    let filter = `?pageNo=${this.pagerDto.currentPage}&pageSize=${this.pagerDto.pageSize}${searchText}`;
    this.service.get(filter)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      })).subscribe(result => {
        this.foodItemsList = result.data.results;
        this.pagerDto = result.data;        
      });
  }

  search() {
    this.pagerDto.currentPage = 1;
    this.getData();
  }

  add() {
    this.router.navigate([config.admin.manageNeutrints.route, 0]);
  }

  edit(foodItemId: number) {
    this.router.navigate([config.admin.manageNeutrints.route, foodItemId]);
  }

  delete(foodItemId: number) {
    if (confirm("هل انت متأكد من مسح هذا الصنف ؟ ")) {
      this.service.delete(foodItemId).subscribe(c => {
        console.log(c);
        this.toastrService.info('تم مسح الصنف بنجاح');
        this.foodItemsList = this.foodItemsList.filter(obj => obj.id !== foodItemId);
      });
    }

  }
}
