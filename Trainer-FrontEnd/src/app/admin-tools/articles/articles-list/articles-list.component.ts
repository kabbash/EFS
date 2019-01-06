import { Component, OnInit } from '@angular/core';
import { articleListItemDto } from 'src/app/shared/models/article-list-item-dto';
import { environment } from 'src/environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { ddlDto, ddlItemDto } from 'src/app/shared/models/ddl-dto';
import { ArticlesFilter } from 'src/app/shared/models/articles-filter';

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
