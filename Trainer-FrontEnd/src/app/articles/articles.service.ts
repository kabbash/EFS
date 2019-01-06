import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {

  constructor(private http: HttpClient) { }

  getArticles(pageNo, pageLimit) {
    return this.http.get(environment.baseUrl + `articles?pageNo=${pageNo}&pageSize=${pageLimit}`);
  }
}
