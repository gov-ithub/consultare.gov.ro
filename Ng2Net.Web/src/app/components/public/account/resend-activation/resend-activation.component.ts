import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserAccountService, ContentService } from '../../../../services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-public-resend-activation',
  templateUrl: './resend-activation.component.html',
  styleUrls: ['./resend-activation.component.css']
})
export class PublicResendActivationComponent implements OnInit {

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

    this.userAccountService.resendActivationLink(this.email).subscribe((result) => {
      this.result = result;
    });
  }
}
