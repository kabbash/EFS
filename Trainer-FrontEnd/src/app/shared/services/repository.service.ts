import { Injectable } from '@angular/core';
import { HttpHeaders } from "@angular/common/http";
import { HttpClient } from "@angular/common/http";
import { apiUrl } from "src/config/api.config";

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient) { }

  public getData(route: string) {
    return this.http.get(this.createCompleteRoute(route));
  }

  public create(route: string, body) {
    return this.http.post(this.createCompleteRoute(route), body, this.generateHeaders());
  }

  public update(route: string, body) {
    return this.http.put(this.createCompleteRoute(route), body, this.generateHeaders());
  }

  public delete(route: string) {
    return this.http.delete(this.createCompleteRoute(route));
  }

  private createCompleteRoute(route: string) {
    return `${apiUrl.repository.base}/${route}`;
  }

  private generateHeaders() {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
