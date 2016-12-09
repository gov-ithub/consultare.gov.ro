import { Component, OnInit, ViewChild, ChangeDetectorRef, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserAccountService, ContentService, InstitutionService } from '../../../../services';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class PublicSignupComponent implements OnInit {

  public currentUser: any = { subscribedToAll: true };
  @ViewChild('myForm')
  private myForm: NgForm;
  private signup: boolean = true;
  private signupResult: boolean = false;
  private showError: boolean = false;

  @Input()
  public edit: boolean;
  private institutions: any[];
  constructor( private activeModal: NgbActiveModal, 
  private userAccountService: UserAccountService,
  private contentService: ContentService,
  private institutionService: InstitutionService,
  public changeDetectorRef: ChangeDetectorRef,
  public route: ActivatedRoute,
  private modalService: NgbModal,
 ) { }

  ngOnInit() {
    if (this.userAccountService.currentUser.id)
      this.currentUser = this.userAccountService.currentUser;
    this.institutionService.getInstitutions().subscribe(result => { 
      this.institutions = result;
      if (this.currentUser.subscriptions)
        this.institutions.forEach(sub => {
          let institution = this.currentUser.subscriptions.filter(inst => inst.id === sub.id)[0];
          if (institution) {
            sub.selected = true;
          }
        });
      this.changeDetectorRef.detectChanges();
    });
  }


  userRegister() {
    if (!this.myForm.valid) {
      this.showError = true;
      return;
    }
    this.currentUser.subscriptions = this.institutions.filter(i => i.selected);
    this.userAccountService.register(this.currentUser).subscribe((result) => {
      if (!result.error) {
        this.signup=false;
        this.signupResult=true;
      }
    });
  }

  openResendEmail() {
    let modal = this.modalService.open(PublicSignupComponent, { keyboard: false });
  }
}
