import { Injectable } from '@angular/core';
import { InterceptorService } from 'ng2-interceptors';
import { Observable } from 'rxjs';

@Injectable()
export class ProposalsService {

  constructor(private http:InterceptorService) { }

  getDocuments(): Observable<any> {
    return this.http.get('/api/proposal/find').map((result)=>result.json());
  }

}
