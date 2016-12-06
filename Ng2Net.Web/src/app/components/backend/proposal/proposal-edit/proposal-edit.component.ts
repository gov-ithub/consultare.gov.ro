import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ProposalsService, HttpClient } from '../../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';
import { InstitutionListComponent } from '../../';

@Component({
  selector: 'app-proposal-edit',
  templateUrl: './proposal-edit.component.html',
  styleUrls: ['./proposal-edit.component.css']
})
export class ProposalEditComponent implements OnInit {

  @Input()
  private proposal: any = {};
  private parentComponent: any = {};
  private result: string;
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(private modalService: NgbModal, private proposalService: ProposalsService, private http: HttpClient ) { }

  ngOnInit() {
  }

  browseInstitution(){
    let modal = this.modalService.open(InstitutionListComponent, { size: 'lg', keyboard: false });
    modal.componentInstance.parentComponent = this;
  }

  save() {
    if (!this.myForm.valid) {
      return;
    }
    this.proposalService.saveProposal(this.proposal).subscribe(result => {
      this.proposal = result;
      this.result = 'Informatiile au fost salvate';
      this.parentComponent.refresh(); });
  }
}
