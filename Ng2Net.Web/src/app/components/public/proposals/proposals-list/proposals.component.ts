import { Component, OnInit, Input } from '@angular/core';
import { ProposalsService, InstitutionService } from '../../../../services';

@Component({
  selector: 'app-proposals',
  templateUrl: './proposals.component.html',
  styleUrls: ['./proposals.component.css']
})
export class ProposalsComponent implements OnInit {

  private institutions: any[];
  private items: any = [];
  private filterQuery: string = '';
  @Input()
  public showSearch: boolean;
  constructor(private proposalsService: ProposalsService,
    private institutionService: InstitutionService
) { }

  ngOnInit() {
    this.refreshData(0);
    this.institutionService.getInstitutions().subscribe(result => {this.institutions = result;});

  }

  refreshData(pageNo: number)
  {
      this.proposalsService.listProposals(this.filterQuery, pageNo, 5).subscribe((result) => {
        this.items = result;
      });
  }

}
