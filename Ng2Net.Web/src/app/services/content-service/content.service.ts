import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { HttpClient } from '../httpClient/httpClient';

@Injectable()
export class ContentService {
  
  public htmlContent: any = {};

  constructor(private http: HttpClient) { 
    this.getHtmlContents();
  }

  getHtmlContents(): any {
    this.http.get(`/api/content/get`)
    .map(result => result.json()).subscribe(result => {
      this.htmlContent = result;
      console.log(this.htmlContent);
    }); 
  }

  listHtmlContents(filterQuery: string = null, pageNo = 0, pageSize = 0) {
    let params = new URLSearchParams();
    params.set('filterQuery', filterQuery);
    params.set('page', pageNo.toString());
    params.set('pageSize', pageSize.toString());

    let obs = this.http.get(`/api/content/list`, { search: params })
    .map(result => result.json()).share();
    return obs;
  }

  getHtmlContent(id: string) {
    let obs = this.http.get(`/api/content/get/${id}`)
    .map(result => result.json()).share();
    return obs;
  }

  saveHtmlContent(htmlContent: any) {
    let obs = this.http.post(`/api/content/save`, htmlContent)
    .map(result => result.json()).share();
    obs.subscribe(() => this.getHtmlContents());
    return obs;
  }

  deleteHtmlContent(id: string) {
    let obs = this.http.delete(`/api/content/${id}`)
    .map(result => result.json()).share();
    obs.subscribe(() => this.getHtmlContents());
    return obs;
  }
}
