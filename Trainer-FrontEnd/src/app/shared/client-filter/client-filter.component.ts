import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-client-filter',
  templateUrl: './client-filter.component.html',
  styleUrls: ['./client-filter.component.css']
})
export class ClientFilterComponent implements OnInit {

  @Output() search: EventEmitter<any> = new EventEmitter();
  searchTxt: string = "";

  constructor() { }

  ngOnInit() {
  }

  searchClicked(){
    this.search.emit();
  }
}
