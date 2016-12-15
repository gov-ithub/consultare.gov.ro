import { Injectable } from '@angular/core';
import { HttpClient } from '../httpClient/httpClient';
import { Observable } from 'rxjs';
import { URLSearchParams } from '@angular/http';

@Injectable()
export class ProposalsService {

  constructor(private http: HttpClient) { }

  
  listProposals(filter: string, institutionId: string, pageNo: number, pageSize: number, futureOnly: boolean, sortField: string, sortDirection: string): Observable<any> {
    let params = new URLSearchParams();
    if (filter && filter !== '')
      params.set('filterQuery', filter);
    if (institutionId && institutionId !== '')
      params.set('institutionId', institutionId);
    params.set('futureOnly', futureOnly.toString());
    params.set('sortField', sortField);
    params.set('sortDirection', sortDirection);
    
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
    console.log(proposal);
    let obs = this.http.post(`/api/proposals/save`, proposal)
    .map(result => result.json()).share();
    return obs;
  }

  deleteProposal(proposal: any) {
    let obs = this.http.delete(`/api/proposals/${proposal.id}`)
    .share();
    return obs;
  }

  deleteDocument(proposalId: string, docId: string) {
    let obs = this.http.delete(`/api/proposals/document/delete/${proposalId}/${docId}`)
    .share();
    return obs;
  }

}
