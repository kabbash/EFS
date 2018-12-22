import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { articleCategoryDto } from '../../shared/models/article-category-dto';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-manage-categories',
  templateUrl: './manage-categories.component.html',
  styleUrls: ['./manage-categories.component.css']
})
export class ManageCategoriesComponent implements OnInit {
  categories: articleCategoryDto [];
  baseurl = environment.filesBaseUrl;
  @Input() addUrl: string;
  @Input() apiUrl: string;
  constructor(private route: ActivatedRoute,
    private router: Router,
    public categoryService: CategoriesService) { }

  ngOnInit() {

  }

  gotoAddCategory() {
    this.categoryService.articleCategoryToEdit = null;
    this.categoryService.apiUrl = this.apiUrl;
    this.router.navigate([this.addUrl]);
  }

}
