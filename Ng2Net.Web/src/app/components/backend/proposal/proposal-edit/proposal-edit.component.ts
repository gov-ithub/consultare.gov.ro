import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ProposalsService, HttpClient, InstitutionService } from '../../../../services';
import { NgForm } from '@angular/forms';
import { InstitutionListComponent, DocumentEditComponent } from '../../';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import * as moment from 'moment';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';


@Component({
  selector: 'app-proposal-edit',
  templateUrl: './proposal-edit.component.html',
  styleUrls: ['./proposal-edit.component.css']
})
export class ProposalEditComponent implements OnInit {

  @Input()
  private proposal: any = {};
  private institutions: any[] = [];
  private parentComponent: any = {};
  private result: string;
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(private proposalService: ProposalsService, private http: HttpClient, private route: ActivatedRoute,
    private institutionService: InstitutionService, private location: Location, private modalService: NgbModal, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params['id'])
        this.proposalService.getProposal(params['id']).subscribe(result => { this.proposal = result; });
    });
    this.institutionService.getInstitutions().subscribe(result => this.institutions = result);
  }

  save() {
    if (!this.myForm.valid) {
      return;
    }
    this.proposalService.saveProposal(this.proposal).subscribe(result => {
      if (!this.proposal.id) {
        this.router.navigateByUrl("admin/proposal-edit/" + result.id);
      }
      else {
      this.proposal = result;
      this.result = 'Informatiile au fost salvate';
      }
    });
  }

  back() {
    this.location.back();
  }
  
  getMoment(date) {
    return moment(date).format('YYYY-MM-DD[T]HH:mm:ss');
  }

  openEditDocument(doc: any = {}) {
    let modal = this.modalService.open(DocumentEditComponent, { keyboard: false });
    modal.componentInstance.document = doc;
    modal.componentInstance.proposal = this.proposal;
    modal.componentInstance.opener = this;
  }
  deleteDocument(docId: string) {
    this.proposalService.deleteDocument(this.proposal.id, docId).subscribe(r=> this.ngOnInit());
  }

}
