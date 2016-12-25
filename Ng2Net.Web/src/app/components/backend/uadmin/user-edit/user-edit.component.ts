import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { UserAccountService, HttpClient } from '../../../../services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  @Input()
  private user: any = {};
  private parentComponent: any = {};
  private userRoles: any[] = [];
  private userRoleid: string = '';
  private identityRoles: any[] = [];
  @ViewChild('ngForm')
  private ngForm: NgForm;
  private result: string;
  private addRoleOpen: boolean = false;

  constructor(private activeModal: NgbActiveModal, private userService: UserAccountService) { }

  ngOnInit() {
    if(this.user.id){
      this.refresh();
    }

    this.userService.listIdentityRoles().subscribe(result=>{this.identityRoles=result});
  }

  refresh(){
    this.userService.listUserRoles(this.user.id).subscribe(result => {
      this.userRoles = result
    });
  }

  addRole(){
    if (!this.addRoleOpen) { 
      this.addRoleOpen=true;
      return;
    }

    this.userService.grantUserRole(this.user.id, this.userRoleid).subscribe(result=>{
      this.refresh();
    });
  }

  deleteRole(role:any){
    this.userService.removeUserRole(this.user.id, role.id).subscribe(result=>{
      this.refresh();
    });
  }

  save() {
     console.log('done');
    if (!this.ngForm.valid) {
      return;
    }
    this.userService.register(this.user).subscribe(result => {
      this.user = result;
      this.result = 'Informatiile au fost salvate';
      this.parentComponent.refresh();
    });
  }
}
