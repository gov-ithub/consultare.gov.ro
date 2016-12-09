import { Component, OnInit, ViewChild } from '@angular/core';
import { UserAccountService, ContentService } from '../../../../services';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-public-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class PublicResetPasswordComponent implements OnInit {

  private m_password: string = '';
  private repeatPassword: string = '';
  private result: any = {};
  public userId: string;
  public token: string;
  private queryParams: any = {};
  private showError: boolean = false;

  @ViewChild('myForm')
  private myForm: NgForm;



  constructor(private userAccountService: UserAccountService, private route: ActivatedRoute, private contentService: ContentService, private activeModal: NgbActiveModal) {
  }
  
  ngOnInit() {
  }

  resetPassword() {

    this.showError = !this.myForm.valid;
    if (!this.myForm.valid)
      return;
      console.log(this.userId + ' ====> ' + this.token);
        this.userAccountService.resetPassword(this.userId, this.token, this.m_password).subscribe((result) => {
      this.result = result;
    });

  }
}
