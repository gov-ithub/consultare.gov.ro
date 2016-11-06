import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserAccountService } from '../../../services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public currentUser:any = {}; 
  private loginError:string;
  constructor(private activeModal: NgbActiveModal, private userAccountService: UserAccountService) { 
  }

  ngOnInit() {
  }

  userLogin(){ 
    this.userAccountService.login(this.currentUser).subscribe((result)=>{
      if (result.error)
        this.loginError=result.error_description;
      else
        this.activeModal.close();
    });
  }
}
