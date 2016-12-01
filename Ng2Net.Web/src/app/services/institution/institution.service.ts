import { Injectable } from '@angular/core';
import { HttpClient } from '../httpClient/httpClient';

@Injectable()
export class InstitutionService {

  constructor(private http: HttpClient) { }

  getInstitutions()
  {
    let obs = this.http.get('/api/institutions/get').map((result) => result.json()).share();
    return obs;
  }

}
