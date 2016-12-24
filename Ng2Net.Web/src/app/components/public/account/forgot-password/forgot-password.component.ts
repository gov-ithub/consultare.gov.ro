import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserAccountService, ContentService } from '../../../../services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-public-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class PublicForgotPasswordComponent implements OnInit {

  public currentUser: any = {};
  @ViewChild('myForm')
  private myForm: NgForm;
  private email: string = '';
  private result: any = {};


  constructor(private activeModal: NgbActiveModal,
    private userAccountService: UserAccountService,
    private contentService: ContentService,
  ) { }

  ngOnInit() {
  }

  sendPasswordReset() {
    console.log(this.email);
    if (!this.myForm.valid) {
      return;
    }

    this.userAccountService.sendResetPasswordLink(this.email).subscribe((result) => {
      this.result = result;
    });
  }
}
