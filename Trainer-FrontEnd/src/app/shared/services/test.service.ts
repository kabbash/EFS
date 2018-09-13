import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from 'src/config/api.config';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private httpClient: HttpClient) { }
  public getAll() {
    const url = apiUrl.test.get;
    return this.httpClient.get<Array<any>>(url);
  }
}

