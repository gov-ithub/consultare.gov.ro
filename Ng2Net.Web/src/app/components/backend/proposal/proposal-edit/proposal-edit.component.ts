import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ProposalService } from '../../../../services';
import { NgForm } from '@angular/forms';

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

  constructor(private proposalService: ProposalService ) { }

  ngOnInit() {
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
