import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoriesService } from '../services/categories.service';
import { config } from 'src/app/config/pages-config';

@Component({
  selector: 'app-manage-products-categories',
  templateUrl: './manage-products-categories.component.html',
  styleUrls: ['./manage-products-categories.component.css']
})
export class ManageProductsCategoriesComponent implements OnInit {

  addUrl = config.admin.addArticleCategory.route;
  constructor(private route: ActivatedRoute, private categoryService: CategoriesService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.categoryService.categoryList = result.categories.data;
    });
  }

}
