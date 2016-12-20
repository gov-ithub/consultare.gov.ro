import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentService, UserAccountService } from '../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PublicResetPasswordComponent, PublicConfirmAccountComponent, PublicSignupComponent, PublicLoginComponent } from '../';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  constructor(private contentService: ContentService, private route: ActivatedRoute,
    private modalService: NgbModal, private userAccountService: UserAccountService) {
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
      case 'unsubscribe':
      userAccountService.getCurrentUser().subscribe(() => {
          if (userAccountService.currentUser.id) {
            let unsubscribeModal = this.modalService.open(PublicSignupComponent, { keyboard: false });
          } else {
            let unsubscribeModal = this.modalService.open(PublicLoginComponent, { size:'sm', keyboard: false });
            unsubscribeModal.componentInstance.redirectTo = "signup";
          }
        });
        break;
      default:
    }
  }

  ngOnInit() {
  }

}
