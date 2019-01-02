import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoriesService } from '../../services/categories.service';
import { config } from '../../../config/pages-config';

@Component({
  selector: 'app-manage-articles-categories',
  templateUrl: './manage-articles-categories.component.html',
  styleUrls: ['./manage-articles-categories.component.css']
})
export class ManageArticlesCategoriesComponent implements OnInit {

  constructor(private route: ActivatedRoute, private categoryService: CategoriesService) { }
  addUrl = config.admin.addCategory.route;
  ngOnInit() {
    this.route.data.subscribe(result => {
      this.categoryService.allCategoriesList = result.categories.data;
    });
    this.categoryService.showParentDdl = false;
  }

}
