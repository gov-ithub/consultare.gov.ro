import { Injectable } from '@angular/core';
import { CookieService } from 'angular2-cookie/services/cookies.service';
import { InterceptorService } from 'ng2-interceptors';
import { Headers } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/share';

@Injectable()
export class UserAccountService {

  private currentUser: any;

  constructor(private cookieService: CookieService, private http: InterceptorService) {
    this.getCurrentUser();
  }

  login(loginModel: any): Observable<any> {
    var body = 'UserName=' + loginModel.email + '&Password=' + loginModel.password + '&grant_type=password';
    var headers = new Headers();
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    
    var obs = this.http.post('/api/token', body, { headers:headers }).map((result)=>result.json()).share();

      obs.subscribe((result)=>{
        var expDate = new Date();
        expDate.setSeconds(expDate.getSeconds() + result.expires_in);
        this.cookieService.put("auth_token", result.access_token, { expires: expDate });
        this.getCurrentUser(true);
      });
      return obs;
  }
  
  getCurrentUser(force:boolean = false) {
    if (this.currentUser===undefined || force)
    {
      this.http.get('/api/account/me').map((result)=>result.json()).subscribe((result)=>
        {
          this.currentUser=result;
          console.log(this.currentUser);
        });
    }
  }
}
