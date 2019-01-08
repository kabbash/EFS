import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-articles-list-item',
  templateUrl: './articles-list-item.component.html',
  styleUrls: ['./articles-list-item.component.css']
})
export class ArticlesListItemComponent implements OnInit {
  @Input() cardName: string;
  @Input() cardImage: string;
  @Input() cardShortDescription: string;
  @Input() hideShowMorelink: boolean;

  articleId: number;

  constructor(private router: Router, private appService: AppService) { }

  ngOnInit() {
  }
}
