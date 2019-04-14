import { Component, OnInit } from '@angular/core';
import { FoodItem } from '../../shared/models/neutrints/food-item-dto';
import { Subject } from 'rxjs';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/map';
import { NeutrintsService } from '../../shared/services/neutrints.service';
import { AppService } from 'src/app/app.service';

@Component({
  selector: 'app-your-tools-meals-catergories',
  templateUrl: './meals.component.html',
  styleUrls: ['./meals.component.css']
})
export class MealsComponent implements OnInit {

  showModal = false;
  rows: FoodItem[];
  selected: FoodItem[] = [];
  searchTextChanged = new Subject<string>();
  searchTxt = '';
  servingAmont: number;
  selectedFoodItems: FoodItem[] = [];
  loading = false;

  constructor(private service: NeutrintsService, public appService: AppService) { }

  ngOnInit() {
    this.searchTextChanged
      .debounceTime(1000)
      .distinctUntilChanged()
      .mergeMap(search => this.getValues())
      .subscribe(() => { });
  }

  get item() {
    return this.selectedFoodItems.reduce((a, b) => {
      let foodItem = new FoodItem();
      for (const key in foodItem) {
        if (key != 'id' && key != 'amount' && typeof foodItem[key] === 'number') {
          foodItem[key] = a[key] + b[key];
        }
      }
      return foodItem;
    }, new FoodItem())
  }

  getValues() {
    this.loading = true;
    return this.service.get(`?searchText=${this.searchTxt}&pageNo=1&pageSize=50`)
      .map(
        (res) => {
          if (res.status == 200) {
            this.rows = res.data.results;
          } else {
            this.rows = [];
          }
          this.loading = false;
        }
      )
  }
  search($event) {
    this.searchTextChanged.next($event.target.value);
  }
  onSelect({ selected }) {
    this.selected = selected;
  }

  openModal() {
    this.showModal = true;
  }

  addFoodItem() {
    if (this.selected) {
      let foodItem = this.selected[0];
      let factor = this.servingAmont / foodItem.amount;
      for (const key in foodItem) {
        if (key != 'id' && key != 'amount' && typeof foodItem[key] === 'number') {
          foodItem[key] = foodItem[key] * factor;
        } 
      }
      foodItem.amount = this.servingAmont;
      this.searchTxt = '';
      this.rows = [];
      this.servingAmont = null;
      this.selectedFoodItems.push(foodItem);
      this.selectedFoodItems = [...this.selectedFoodItems]
      this.showModal = false;
    }
  }

  removeFoodItem(foodItemId) {
    let foodItem = this.selectedFoodItems.find(obj => obj.id == foodItemId);
    var index = this.selectedFoodItems.indexOf(foodItem, 0);
    if (index >= 0) {
      this.selectedFoodItems.splice(index, 1);
    }
  }

}
