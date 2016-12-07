import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserAccountService, ContentService } from '../../../../services';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PublicForgotPasswordComponent, PublicResendActivationComponent } from '../../';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class PublicLoginComponent implements OnInit {

  public currentUser: any = {};
  @ViewChild('myForm')
  private myForm: NgForm;
  private login: boolean = true;
  private forgotPassword: boolean = false;
  private resendActivation: boolean = false;

  constructor( private activeModal: NgbActiveModal, 
  private userAccountService: UserAccountService,
  private contentService: ContentService,
  private modalService: NgbModal,
 ) {
  }

  ngOnInit() { 
  }

  userLogin() {
    if (!this.myForm.valid)
      return;
    this.userAccountService.login(this.currentUser).subscribe((result) => {
      if (!result.error) {
        this.activeModal.close();
      }
    });
  }

    hideAllDivs() {
    this.login = false;
    this.forgotPassword = false;
    this.resendActivation = false;
  }



  openResendEmail() {
    this.activeModal.close();
    this.modalService.open(PublicResendActivationComponent, { size: 'sm', keyboard: false });
  }

  openForgotPassword() {
    this.activeModal.close();
    this.modalService.open(PublicForgotPasswordComponent, { size: 'sm', keyboard: false});
  }

}
