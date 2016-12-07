import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentService } from '../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PublicResetPasswordComponent, PublicConfirmAccountComponent } from '../';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(private contentService: ContentService, private route: ActivatedRoute,
    private modalService: NgbModal) {
    switch(route.snapshot.data['action']) {
      case 'resetPassword':
        let modal = this.modalService.open(PublicResetPasswordComponent, { keyboard: false });
        modal.componentInstance.userId = route.snapshot.params['userId'];
        modal.componentInstance.token = route.snapshot.queryParams['token'];
        break;
      case 'confirmAccount':
        let confirmAccountModal = this.modalService.open(PublicConfirmAccountComponent, { keyboard: false });
        confirmAccountModal.componentInstance.userId = route.snapshot.params['userId'];
        confirmAccountModal.componentInstance.token = route.snapshot.queryParams['token'];
        confirmAccountModal.componentInstance.confirmAccount();
        break;
      default:
    }
  }

  ngOnInit() {
  }

}
