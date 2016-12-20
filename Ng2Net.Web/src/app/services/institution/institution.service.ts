import { Injectable } from '@angular/core';
import { HttpClient } from '../httpClient/httpClient';
import { Observable } from 'rxjs';
import { URLSearchParams } from '@angular/http';

@Injectable()
export class InstitutionService {

  constructor(private http: HttpClient) { }

  getInstitutions() {
    let obs = this.http.get('/api/institutions/get').map((result) => result.json()).share();
    return obs;
  }

  listInstitutions(filter: string, pageNo: number, pageSize: number): Observable<any> {
    let params = new URLSearchParams();
    if (filter && filter !== '')
      params.set('filterQuery', filter);

    params.set('pageNo', pageNo.toString());
    params.set('pageSize', pageSize.toString());
    return this.http.get('/api/institutions/find', { search: params }).map((result) => result.json());
  }

  getInstitution(id: string) {
    let obs = this.http.get(`/api/institutions/get/${id}`)
      .map(result => result.json()).share();
    return obs;
  }

  saveInstitution(institution: any) {
    let obs = this.http.post(`/api/institutions/save`, institution)
      .map(result => result.json()).share();
    return obs;
  }

  deleteInstitution(id: string, destinationInstitutionId: string = '') {
    let obs = this.http.delete(`/api/institutions/${id}/${destinationInstitutionId}`).share();
    return obs;
  }

}
