import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import 'rxjs/add/operator/share';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';
import { CookieService } from 'angular2-cookie/services/cookies.service';


@Injectable()
export class HttpClient {

    public loading: BehaviorSubject<number> = new BehaviorSubject(0);

    constructor(private http: Http, private cookieService: CookieService) {
        
    }

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        this.loading.next(this.loading.value + 1);
        options = this.createAuthHeader(options);
        let retValue = this.http.get(environment.apiUrl + url, options).share();
        retValue
        .catch(() => { return Observable.of(true); })
        .subscribe(res => this.loading.next(this.loading.value - 1));
        return retValue;
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        this.loading.next(this.loading.value + 1);
        options = this.createAuthHeader(options);
        let retValue = this.http.delete(environment.apiUrl + url, options).share();
        retValue
        .catch(() => { return Observable.of(true); })
        .subscribe(res => this.loading.next(this.loading.value - 1));
        return retValue;
    }

    post(url: string, data: any, options?: RequestOptionsArgs): Observable<Response> {
        this.loading.next(this.loading.value + 1);
        options = this.createAuthHeader(options);
        if (data !== null)
            options.headers.append('Content-Type', 'application/json');
        let retValue = this.http.post(environment.apiUrl + url, data, options).share();
        retValue
        .catch(() => { return Observable.of(true); })
        .subscribe(res => this.loading.next(this.loading.value - 1));
        return retValue;
    }

    private createAuthHeader(options: RequestOptionsArgs): RequestOptionsArgs {
        let headers = new Headers({'Accept': 'application/json'}); 
        
        let authToken = this.cookieService.get('auth_token');
        if (authToken !== '') {
            headers.append('Authorization', 'Bearer ' + authToken);
        }

       if (!options)
            options = new RequestOptions({ headers: headers });
            
        options.headers = headers;
        
        return options;
    }
}
