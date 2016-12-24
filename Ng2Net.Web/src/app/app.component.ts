import { Component, OnInit, Inject } from '@angular/core';
import { UserAccountService, HttpClient } from './services';
import { Router, NavigationEnd } from '@angular/router';
import * as moment from 'moment';
import 'moment/locale/ro';
declare var ga:any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {

  constructor(private userService: UserAccountService, private http: HttpClient, private router: Router) {
    moment.locale("ro");
  };

  ngOnInit() {
    this.userService.getCurrentUser(true);
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
          return;
      }
      document.body.scrollTop = 0;
      if (!evt.url.toLowerCase().startsWith('/admin')) {
        ga('send', 'pageview', { page: evt.url });
      }
    });
  }
}
