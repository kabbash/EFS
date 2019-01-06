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
                                    ]
      this.articlesStatuses.selectedValue = 1;                                    
    }

    articlesDetails(articleId){
      this.router.navigate([config.admin.manageArticles.route, articleId]);
    }

    // approve(articleId){
    //   if(confirm("هل انت متأكد من الموافقه على هذا المقال ؟ ")){      
    //     this.service.approve(articleId).subscribe(c=> { console.log(c); alert('approved'); });
    //   }
    // }
  
    //   reject(articleId){
    //     if(confirm("هل انت متأكد من رفض هذا المقال ؟ ")){
    //       this.service.reject(articleId).subscribe(c=> { console.log(c); alert('rejected'); });
    //     }
    // }

    reloadItems(){
      debugger;
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
