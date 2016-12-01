import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserAccountService, ContentService, InstitutionService } from '../../../services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class PublicSignupComponent implements OnInit {

  public currentUser: any = {};
  @ViewChild('myForm')
  private myForm: NgForm;

  private institutions: any[];
  constructor( private activeModal: NgbActiveModal, 
  private userAccountService: UserAccountService,
  private contentService: ContentService,
  private institutionService: InstitutionService,
  public changeDetectorRef: ChangeDetectorRef
 ) { }

  ngOnInit() {
    this.institutionService.getInstitutions().subscribe(result => {this.institutions = result;this.changeDetectorRef.detectChanges();});
  }



  userRegister() {
    if (!this.myForm.valid)
      return;
    this.userAccountService.login(this.currentUser).subscribe((result) => {
      if (!result.error) {
        this.activeModal.close();
      }
    });
  }
}
