import { Injectable } from '@angular/core';
import { HttpClient } from '../httpClient/httpClient';
import { Observable } from 'rxjs';
import { URLSearchParams } from '@angular/http';

@Injectable()
export class ProposalsService {

  constructor(private http: HttpClient) { }

  getDocuments(filter: string, pageNo: number, pageSize: number): Observable<any> {
    let params = new URLSearchParams();
    if (filter && filter !== '')
      params.set('filterQuery', filter);

    params.set('pageNo', pageNo.toString());
    params.set('pageSize', pageSize.toString());
    return this.http.get('/api/proposals/find', {search: params}).map((result) => result.json());
  }
}
