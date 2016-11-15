import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserAccountService, ContentService } from '../../../services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class BackendLoginComponent implements OnInit {

  public currentUser: any = {};
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(// private activeModal: NgbActiveModal, 
  private userAccountService: UserAccountService,
  private router: Router,
  private contentService: ContentService,
  private activatedRoute: ActivatedRoute ) { }

  ngOnInit() { 
  }

  userLogin() {
    if (!this.myForm.valid)
      return;
    this.userAccountService.login(this.currentUser).subscribe((result) => {
      if (!result.error) {
        this.router.navigate([ this.activatedRoute.snapshot.parent.url.toString() + "/" + (this.userAccountService.redirectTo || '') ]);
      }
    });
  }
}
