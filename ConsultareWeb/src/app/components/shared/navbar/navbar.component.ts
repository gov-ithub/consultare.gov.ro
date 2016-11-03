import { Component, OnInit } from '@angular/core';
import { ProposalsService } from '../../../services/proposals/proposals.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from '../index';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private modalService:NgbModal) { }

  ngOnInit() {
  }

  openLogin() {
    const modalRef = this.modalService.open(LoginComponent, { size:'sm', keyboard:false });
  }

}
