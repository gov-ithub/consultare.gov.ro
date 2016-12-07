import { Component, OnInit } from '@angular/core';
import { UserAccountService, HttpClient } from './services';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private userService: UserAccountService, private http: HttpClient, private router: Router) {
  };

  ngOnInit() {
    this.userService.getCurrentUser(true);
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
          return;
      }
      document.body.scrollTop = 0;
    });
  }
}
