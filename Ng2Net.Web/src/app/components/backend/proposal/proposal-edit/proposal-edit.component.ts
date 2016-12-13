import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ProposalsService, HttpClient, InstitutionService } from '../../../../services';
import { NgForm } from '@angular/forms';
import { InstitutionListComponent } from '../../';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import * as moment from 'moment';


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
  private institutionService: InstitutionService, private location: Location ) { }

  ngOnInit() {
    this.route.params.subscribe(params => { 
      if (params['id'])
        this.proposalService.getProposal(params['id']).subscribe(result => { this.proposal = result; console.log(result); });
    });
    this.institutionService.getInstitutions().subscribe(result => this.institutions = result);
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
  back() {
    this.location.back();
  }
    log(x)
  {console.log(x);}
  getMoment(date)
  { 
    return moment(date).format('YYYY-MM-DD[T]HH:mm:ss'); }

}
