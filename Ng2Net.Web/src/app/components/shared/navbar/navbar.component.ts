import { Component, OnInit } from '@angular/core';
import { UserAccountService } from '../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {

  constructor(private modalService: NgbModal, private userService: UserAccountService) { }

  ngOnInit() {
  }

  openLogin() {
  }

}
