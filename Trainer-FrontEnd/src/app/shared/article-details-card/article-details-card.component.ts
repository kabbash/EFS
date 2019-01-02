import { Component, OnInit, Input } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { articleDetialsDto } from '../../shared/models/article-details-dto';
import { AppService } from '../../app.service';

@Component({ 
  selector: 'app-article-details-card',
  templateUrl: './article-details-card.component.html',
  styleUrls: ['./article-details-card.component.css']
})
export class ArticleDetailsCardComponent implements OnInit {

  images = [1, 2, 3].map(() => `https://picsum.photos/900/500?random&t=${Math.random()}`);

  @Input() article: articleDetialsDto;  
  articleBody: string;
  baseurl = environment.filesBaseUrl;

  constructor(private router: Router,
     private route: ActivatedRoute,
      private repositoryService: RepositoryService,
       private appService: AppService) {
  }

  ngOnInit() {
    // this.route.data.subscribe(result => {
    //   this.article = result.details.data;
      this.articleBody = '<h2><center>' + this.article.name + '</center></h2><br/>' + this.article.description;
    //   this.appService.loading = false;
    // });
  }
}
