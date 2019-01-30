import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ddlDto } from '../models/ddl-dto';

@Component({
  selector: 'app-search-filter',
  templateUrl: './search-filter.component.html',
  styleUrls: ['./search-filter.component.css']
})
export class SearchFilterComponent implements OnInit {

  @Output() search: EventEmitter<any> = new EventEmitter();
  filterStatuses = new ddlDto();
  searchTxt: string = "";

  constructor() { }

  ngOnInit() {

    this.filterStatuses.items = [{ value: 0, text: "الكل" }
      , { value: 1, text: "النشط" }
      , { value: 2, text: "المتوقف" }
      , { value: 3, text: "المرفوض" }
    ]
    this.filterStatuses.selectedValue = 0;
  }

  searchClicked(){
    this.search.emit();
  }
}
