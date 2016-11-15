import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserAccountService } from '../../../services/useraccount/user-account.service';
@Component({
  selector: 'app-menu-aside',
  templateUrl: 'menu-aside.component.html',
  styleUrls: ['menu-aside.component.css']
})
export class MenuAsideComponent implements OnInit {

  constructor(private userAccountService: UserAccountService, private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit() {
  }

  logout() {
    this.userAccountService.logout();
    this.router.navigate([this.route.snapshot.url.toString() + `/login`]);
  }
}
