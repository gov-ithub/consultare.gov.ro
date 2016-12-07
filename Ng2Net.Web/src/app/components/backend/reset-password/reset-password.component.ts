import { Component, OnInit, ViewChild } from '@angular/core';
import { UserAccountService, ContentService } from '../../../services';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  private m_password: string = '';
  private repeatPassword: string = '';
  private result: any = {};
  private params: any = {};
  private queryParams: any = {};
  private showError: boolean = false;

  @ViewChild('myForm')
  private myForm: NgForm;



  constructor(private userAccountService: UserAccountService, private route: ActivatedRoute, private contentService: ContentService) {
  }
  
  ngOnInit() {
    this.route.params.subscribe((res) => {
      this.params = res; 
    });
    this.route.queryParams.subscribe((res) => {
      this.queryParams = res;
    });
  }

  resetPassword() {
    this.showError = !this.myForm.valid;
    if (!this.myForm.valid)
      return;
    this.userAccountService.resetPassword(this.params['userId'], this.queryParams['token'], this.m_password).subscribe((result) => {
      this.result = result;
    });

  }
}
