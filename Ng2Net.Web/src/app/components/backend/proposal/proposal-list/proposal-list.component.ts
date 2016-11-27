import { Component, OnInit } from '@angular/core';
import { ProposalService, HttpClient } from '../../../../services';
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

  constructor(private router: Router, private route: ActivatedRoute, private proposalService: ProposalService, private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.proposalService.listProposals(this.filterQuery).subscribe(result => this.proposals = result);
  }

  openEdit(proposal: any) {
    this.router.navigate([`/proposal-edit`]);
  }

  delete(proposal: any) {
    if (confirm('Are you sure?')) {
    this.proposalService.deleteProposal(proposal.id).subscribe(() => this.refresh());
    }
  }
}
