import { Component, OnInit } from '@angular/core';
import { UserAccountService, HttpClient } from './services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private userService: UserAccountService, private http: HttpClient) {
  };

  ngOnInit() {
    this.userService.getCurrentUser(true);
  }
}
