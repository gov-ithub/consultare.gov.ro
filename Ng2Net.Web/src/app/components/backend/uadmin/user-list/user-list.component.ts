import { Component, OnInit } from '@angular/core';
import { UserAccountService, HttpClient } from '../../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserEditComponent } from '../../';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  private users: any[] = [];
  private filterQuery: string = '';


  constructor(private modalService: NgbModal, private userService: UserAccountService, private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.userService.listUsers(this.filterQuery).subscribe(result => {
      this.users = result
    });
  }

  openEdit(user: any) {
    let modal = this.modalService.open(UserEditComponent, { keyboard: false });
    modal.componentInstance.user = user;
    modal.componentInstance.parentComponent = this;
  }

  delete(user: any) {
    if (confirm('Are you sure?')) {
      //this.userService.deleteProposal(proposal).subscribe(() => this.refresh(0));
    }
  }


}
