import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';

@Component({
  selector: 'app-all-demos',
  templateUrl: './all-demos.component.html',
  styleUrls: ['./all-demos.component.css']
})
export class AllDemosComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  navigateForms() {
    this.router.navigate([config.demos.forms.route]);
  }

  navigateDropdowns() {
    this.router.navigate([config.demos.dropdowns.route]);
  }

  navigatePagination() {
    this.router.navigate([config.demos.pagination.route]);
  }

}
