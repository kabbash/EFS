import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { articleDetialsDto } from '../../shared/models/article-details-dto';

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})
export class ArticleDetailsComponent implements OnInit {

  images = [1, 2, 3].map(() => `https://picsum.photos/900/500?random&t=${Math.random()}`);

  article = {};
  articleBody:string;
  baseurl = environment.filesBaseUrl;
  articleId: number;

  constructor(private router: Router, private route: ActivatedRoute, private repositoryService: RepositoryService) {
    this.route.params.subscribe(params => {
      this.articleId = params['articleId'];
    });
  }

  ngOnInit() {
    this.getArticleDetails();
  }
  getArticleDetails() {
    this.repositoryService.getData<articleDetialsDto>('articles/' + this.articleId).subscribe(result => {
      this.article = result.data;
      this.articleBody = "<h2><center>" + result.data.name + "</center></h2><br/>" + result.data.description;
    });
  }
}
