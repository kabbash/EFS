import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { articleListItemDto } from '../../../shared/models/article-list-item-dto';
import { environment } from '../../../../environments/environment';
import { ddlDto } from '../../../shared/models/ddl-dto';
import { config } from '../../../config/pages-config';
import { ArticlesFilter } from '../../../shared/models/articles-filter';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css'],
  providers: [AdminArticlesService]
})
export class ArticlesListComponent implements OnInit {

  articlesList: articleListItemDto [];
  baseurl = environment.filesBaseUrl;
  articlesStatuses = new ddlDto();
  searchTxt : string="";

  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminArticlesService) { }

    ngOnInit() {
      this.route.data.subscribe(result => {
        this.articlesList = result.articlesList.data.results;
      });

      this.articlesStatuses.items = [ { value:1 , text:"الكل" }
                                     ,{ value:2 , text:"النشط" }
                                     ,{ value:3 , text:"المتوقف"}
                                     ,{ value:4 , text:"المرفوض"}
                                    ]
      this.articlesStatuses.selectedValue = 1;                                    
    }

    articlesDetails(articleId){
      this.router.navigate([config.admin.manageArticles.route, articleId]);
    }
    
    addArticle(){
      this.router.navigate([config.admin.manageArticles.route, 0]);
    }

    reloadItems(){
      let articleFilter:ArticlesFilter = {
        pageNo: 1,
        pageSize: 10,
        searchText: this.searchTxt,
        status: this.articlesStatuses.selectedValue         
      };

      let filter = `?pageNo=${articleFilter.pageNo}&pageSize=${articleFilter.pageSize}&searchText=${articleFilter.searchText}&status=${articleFilter.status}`;
      this.service.getFilteredArticles(filter).subscribe(result => {
        this.articlesList = result.data.results;
      });
    }
}
