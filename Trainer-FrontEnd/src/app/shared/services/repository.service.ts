import { Injectable } from '@angular/core';
import { HttpHeaders } from "@angular/common/http";
import { HttpClient } from "@angular/common/http";
import { apiUrl } from "src/config/api.config";
import { ResultMessage } from "src/app/shared/models/result-message";

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient) { }

  public getData<T>(route: string) {
    return this.http.get<ResultMessage<T>>(this.createCompleteRoute(route));
  }

  public create<T>(route: string, body) {
    return this.http.post<ResultMessage<T>>(this.createCompleteRoute(route), body, this.generateHeaders());
  }

  public update<T>(route: string, body) {
    return this.http.put<ResultMessage<T>>(this.createCompleteRoute(route), body, this.generateHeaders());
  }

  public delete<T>(route: string) {
    return this.http.delete<ResultMessage<T>>(this.createCompleteRoute(route));
  }

  private createCompleteRoute(route: string) {
    return `${apiUrl.repository.base}${route}`;
  }

  private generateHeaders() {
    return {
      // headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
