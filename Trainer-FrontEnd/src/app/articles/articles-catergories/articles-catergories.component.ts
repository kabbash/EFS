import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';
import { RepositoryService } from "src/app/shared/services/repository.service";

@Component({
  selector: 'app-articles-catergories',
  templateUrl: './articles-catergories.component.html',
  styleUrls: ['./articles-catergories.component.css']
})
export class ArticlesCatergoriesComponent implements OnInit {

  categories = []
  constructor(private router: Router, private repositoryService: RepositoryService) { }

  ngOnInit() {
    this.getCategories();
  }

  articlesList() {
    this.router.navigate([config.articles.allArticles.route]);
  }

  getCategories() {
    this.repositoryService.getData<any>('articles/categories').subscribe(result => {
      debugger;
      this.categories = result.data;
    });
  }

}
