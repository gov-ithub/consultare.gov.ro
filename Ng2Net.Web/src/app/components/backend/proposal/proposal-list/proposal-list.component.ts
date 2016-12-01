import { Component, OnInit } from '@angular/core';
import { ProposalsService, HttpClient } from '../../../../services';
import { Router, ActivatedRoute } from '@angular/router';
import { ProposalEditComponent } from '../../';

@Component({
  selector: 'app-proposal-list',
  templateUrl: './proposal-list.component.html',
  styleUrls: ['./proposal-list.component.css']
})
export class ProposalListComponent implements OnInit {

  private proposals: any[] = [];
  private filterQuery: string = '';

  constructor(private router: Router, private route: ActivatedRoute, private proposalService: ProposalsService, private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.proposalService.listProposals(this.filterQuery, 0, 50).subscribe(result => this.proposals = result);
  }

  openEdit(proposal: any) {
    this.router.navigate([`admin/proposal-edit`]);
  }

  delete(proposal: any) {
    if (confirm('Are you sure?')) {
    this.proposalService.deleteProposal(proposal.id).subscribe(() => this.refresh());
    }
  }
}
