import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProposalsService } from '../../../../services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-document-edit',
  templateUrl: './document-edit.component.html',
  styleUrls: ['./document-edit.component.css']
})
export class DocumentEditComponent implements OnInit {

  public document: any = {};
  public proposal: any = {};
  public opener: any = {};
  private showError: boolean = false;;
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(private proposalService: ProposalsService, private activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  save() {
    this.showError = true;
    if (this.myForm.valid) {
      if (!this.document.proposalId)
        this.proposal.proposalDocuments[this.proposal.proposalDocuments.length] = this.document;
      this.proposalService.saveProposal(this.proposal).subscribe(result => { 
        this.activeModal.close();
        this.opener.ngOnInit(); 
      });
    }
  }
}
