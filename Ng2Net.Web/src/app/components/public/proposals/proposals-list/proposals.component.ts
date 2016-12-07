import { Component, OnInit, Input } from '@angular/core';
import { ProposalsService, InstitutionService, PagerService, HttpClient } from '../../../../services';

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
  private pageNo: number;
  private pagerInstance = "proposals.component";
  constructor(private proposalsService: ProposalsService,
    private institutionService: InstitutionService,
    private pagerService: PagerService,
    private http: HttpClient,
) { }
  
  ngOnInit() {
    this.refreshData(0);
    this.institutionService.getInstitutions().subscribe(result => {this.institutions = result;});
  }

  refreshData(pageNo: number)
  {
    this.pageNo = pageNo;
    let pageSize = this.showSearch ? 20 : 5;
      this.proposalsService.listProposals(this.filterQuery, pageNo, this.showSearch ? 20 : 5).subscribe((result) => {
        this.items = result.results;
        this.pagerService.refreshInstances(this.pagerInstance, this.pageNo, result.totalResults, pageSize);
     });
  }
}
