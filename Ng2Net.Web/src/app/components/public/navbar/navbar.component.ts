import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { UserAccountService } from '../../../services';
//import { PublicLoginComponent } from '../';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ScrollSpyService } from 'ng2-scrollspy';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit, AfterViewInit {

  constructor(private modalService: NgbModal, private userService: UserAccountService, private scrollSpyService: ScrollSpyService) { }

  private scrollPos: string = 'top';

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.scrollSpyService.getObservable('window').subscribe((e: any) => {
              this.scrollPos = (document.body.scrollTop < 100 ? 'top': 'scroll');
        });
  }

  openLogin() {
    //let modal = this.modalService.open(PublicLoginComponent, { size: 'sm', keyboard: false });
  }

}
