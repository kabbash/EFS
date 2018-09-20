import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from '../../../config/api.config';
import { APP_BASE_HREF } from '@angular/common';
import { Inject } from '@angular/core';
import { Optional } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  url:string;
  constructor(private httpClient: HttpClient, @Optional() @Inject(APP_BASE_HREF) origin:string) { 
    this.url = `${origin} ${apiUrl.test.get}`
  }
  public getAll() {
    return this.httpClient.get<Array<any>>(this.url);
  }
}

