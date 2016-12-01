import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserAccountService, ContentService } from '../../../services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class PublicLoginComponent implements OnInit {

  public currentUser: any = {};
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor( private activeModal: NgbActiveModal, 
  private userAccountService: UserAccountService,
  private contentService: ContentService,
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
}
