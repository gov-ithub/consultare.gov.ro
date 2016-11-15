import { Component, OnInit, ViewChild } from '@angular/core';
import { UserAccountService, ContentService } from '../../../services';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  private email: string = '';
  private result: any = {};
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(private userAccountService: UserAccountService, private contentService: ContentService) { }

  sendPasswordReset() {
    if (!this.myForm.valid) {
      return;
    }

    this.userAccountService.sendResetPasswordLink(this.email).subscribe((result) => {
      this.result = result;
    });
  }

  ngOnInit() {
  }
}
