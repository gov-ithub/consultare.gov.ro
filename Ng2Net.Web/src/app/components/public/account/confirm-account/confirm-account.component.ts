import { Component, ViewChild } from '@angular/core';
import { UserAccountService, ContentService } from '../../../../services';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-public-confirm-account',
  templateUrl: './confirm-account.component.html',
  styleUrls: ['./confirm-account.component.css']
})
export class PublicConfirmAccountComponent {

  private result: any = {};
  public userId: string;
  public token: string;
  private showError: boolean = false;

  @ViewChild('myForm')
  private myForm: NgForm;


  constructor(private userAccountService: UserAccountService, 
  private route: ActivatedRoute, private contentService: ContentService, 
  private activeModal: NgbActiveModal) {
  }

  public confirmAccount() {
    this.showError = true;
    this.userAccountService.confirmAccount(this.userId, this.token).subscribe((result) => {
      this.result = result;
    });
  }

}
