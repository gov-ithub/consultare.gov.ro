import { Component, OnInit } from '@angular/core';
import { ProposalsService, HttpClient, PagerService } from '../../../../services';
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
  private pagerInstance='proposals.component';

  constructor(private router: Router, private route: ActivatedRoute, private proposalService: ProposalsService, private http: HttpClient,
  private pagerService: PagerService) { }

  ngOnInit() {
    this.refresh(0);
  }

  refresh(pageNo: number) {
    this.proposalService.listProposals(this.filterQuery, null, pageNo, this.pagerService.defaultPagerConfig.pageSize, false, 'startDate', 'desc').subscribe(result => {
      this.proposals = result.results
      this.pagerService.refreshInstances(this.pagerInstance, pageNo, result.totalResults);
    });
  }

  openEdit(proposal: any) {
    if (proposal.id)
      this.router.navigate([`admin/proposal-edit/${proposal.id}`]);
    else
      this.router.navigate([`admin/proposal-edit`]);
  }

  delete(proposal: any) {
    if (confirm('Are you sure?')) {
      this.proposalService.deleteProposal(proposal).subscribe(() => this.refresh(0));
    }
  }
}
