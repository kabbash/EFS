import { Component, OnInit, Input } from '@angular/core';
import { articleDetialsDto } from '../models/article-details-dto';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-article-details-editmode',
  templateUrl: './article-details-editmode.component.html',
  styleUrls: ['./article-details-editmode.component.css']
})
export class ArticleDetailsEditmodeComponent implements OnInit {

  @Input() article: articleDetialsDto;
  @Input() isNew: boolean;

  articleBody: string;
  baseurl = environment.filesBaseUrl;

  constructor() { }

  ngOnInit() {

    if (this.isNew)
      this.article = new articleDetialsDto();
    // else
    //   this.articleBody = '<h2><center>' + this.article.name + '</center></h2><br/>' + this.article.description;    
  }
}
