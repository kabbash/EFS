import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';

@Component({
  selector: 'app-articles-catergories',
  templateUrl: './articles-catergories.component.html',
  styleUrls: ['./articles-catergories.component.css']
})
export class ArticlesCatergoriesComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  articlesList() {
    this.router.navigate([config.articles.allArticles.route]);
  }

}
