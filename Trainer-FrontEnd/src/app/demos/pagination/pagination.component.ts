import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  currentPage = 3;
  page = 4;
  pageAdvanced = 2;

  constructor() { }

  ngOnInit() {
  }

}
