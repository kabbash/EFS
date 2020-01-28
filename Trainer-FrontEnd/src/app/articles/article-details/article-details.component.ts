import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { ArticleDetialsDto } from '../../shared/models/articles/article-details-dto';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})
export class ArticleDetailsComponent implements OnInit {

  images = [1, 2, 3].map(() => `https://picsum.photos/900/500?random&t=${Math.random()}`);

  article: ArticleDetialsDto;
  articleBody: string;
  baseurl = environment.filesBaseUrl;
  articleId: number;

  constructor(private router: Router,
     private route: ActivatedRoute,
      private repositoryService: RepositoryService,
       private appService: AppService) {
    this.route.params.subscribe(params => {
      this.articleId = params['articleId'];
    });
  }
 
  ngOnInit() {
    this.route.data.subscribe(result => {
      this.article = result.details.data;
      this.appService.loading = false;
    });
  }

}
