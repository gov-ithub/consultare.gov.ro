import { Injectable } from '@angular/core';
import { HttpClient } from '../httpClient/httpClient';
import { Observable } from 'rxjs';
import { URLSearchParams } from '@angular/http';

@Injectable()
export class ProposalsService {

  constructor(private http: HttpClient) { }

  
  listProposals(filter: string, pageNo: number, pageSize: number): Observable<any> {
    let params = new URLSearchParams();
    if (filter && filter !== '')
      params.set('filterQuery', filter);

    params.set('pageNo', pageNo.toString());
    params.set('pageSize', pageSize.toString());
    return this.http.get('/api/proposals/find', {search: params}).map((result) => result.json());
  }

    getProposal(id: string) {
    let obs = this.http.get(`/api/proposals/get/${id}`)
    .map(result => result.json()).share();
    return obs;
  }

  saveProposal(proposal: any) {
    let obs = this.http.post(`/api/proposals/save`, proposal)
    .map(result => result.json()).share();
    return obs;
  }

  deleteProposal(id: string) {
    let obs = this.http.delete(`/api/proposals/${id}`)
    .map(result => result.json()).share();
    return obs;
  }

}
