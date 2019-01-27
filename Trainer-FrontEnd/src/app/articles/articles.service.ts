import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ActivatedRouteSnapshot } from '@angular/router';

@Injectable()
export class ArticlesService {

  constructor(private http: HttpClient, private route: ActivatedRouteSnapshot) { }

  getArticles(pageNo, pageLimit) {
    return this.http.get(environment.baseUrl + `articles/${this.route.params['categoryId']}?pageNo=${pageNo}&pageSize=${pageLimit}`);
  }

}
