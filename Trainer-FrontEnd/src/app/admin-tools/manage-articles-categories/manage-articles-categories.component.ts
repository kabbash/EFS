import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoriesService } from '../services/categories.service';
import { config } from 'src/app/config/pages-config';

@Component({
  selector: 'app-manage-articles-categories',
  templateUrl: './manage-articles-categories.component.html',
  styleUrls: ['./manage-articles-categories.component.css']
})
export class ManageArticlesCategoriesComponent implements OnInit {

  constructor(private route: ActivatedRoute, private categoryService: CategoriesService) { }
  addUrl = config.admin.addArticleCategory.route;
  ngOnInit() {
    this.route.data.subscribe(result => {
      this.categoryService.categoryList = result.categories.data;
    });
  }

}
