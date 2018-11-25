import { Component, OnInit, Input } from '@angular/core';
import { Router} from '@angular/router';
import { config } from '../../config/pages-config';

@Component({
  selector: 'app-articles-list-item',
  templateUrl: './articles-list-item.component.html',
  styleUrls: ['./articles-list-item.component.css']
})
export class ArticlesListItemComponent implements OnInit {
  @Input() cardName: string;
  @Input() cardImage: string;
  @Input() cardShortDescription: string;
  articleId: number;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  articlesDetails() {
    this.router.navigate([config.articles.articleDetails.route,this.articleId]);
  }
}
