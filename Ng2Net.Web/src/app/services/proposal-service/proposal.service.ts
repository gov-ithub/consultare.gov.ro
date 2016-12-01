import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { HttpClient } from '../httpClient/httpClient';

@Injectable()
export class ProposalService {
  
  public proposal: any = {};

  constructor(private http: HttpClient) { 
    this.getProposals();
  }

  getProposals(): any {
    this.http.get(`/api/proposals/get`)
    .map(result => result.json()).subscribe(result => {
      this.proposal = result;
      console.log(this.proposal);
    }); 
  }

  listProposals(filterQuery: string = null, pageNo = 0, pageSize = 0) {
    let params = new URLSearchParams();
    params.set('filterQuery', filterQuery);
    params.set('page', pageNo.toString());
    params.set('pageSize', pageSize.toString());

    let obs = this.http.get(`/api/proposals/list`, { search: params })
    .map(result => result.json()).share();
    return obs;
  }

  getProposal(id: string) {
    let obs = this.http.get(`/api/proposals/get/${id}`)
    .map(result => result.json()).share();
    return obs;
  }

  saveProposal(proposal: any) {
    let obs = this.http.post(`/api/proposals/save`, proposal)
    .map(result => result.json()).share();
    obs.subscribe(() => this.getProposals());
    return obs;
  }

  deleteProposal(id: string) {
    let obs = this.http.delete(`/api/proposals/${id}`)
    .map(result => result.json()).share();
    obs.subscribe(() => this.getProposals());
    return obs;
  }
}
