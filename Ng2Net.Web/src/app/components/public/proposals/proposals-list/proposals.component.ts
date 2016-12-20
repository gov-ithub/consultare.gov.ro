import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
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
  public institutionId: string;
  private pageNo: number;
  @Input()
  private sortField: string = 'limitDate';
  private sortDirection: string = 'asc';
  @Input()
  private futureOnly: boolean = true;
  private pagerInstance = "proposals.component";
  constructor(private proposalsService: ProposalsService,
    private institutionService: InstitutionService,
    private pagerService: PagerService,
    private http: HttpClient,
    public changeDetectorRef: ChangeDetectorRef
) { }
  
  ngOnInit() {
    this.refreshData(0);
    this.institutionService.getInstitutions().subscribe(result => {this.institutions = result;});
  }
  
  refreshData(pageNo: number)
  {
    this.pageNo = pageNo;
    let pageSize = this.showSearch ? 20 : 5;
      this.proposalsService.listProposals(this.filterQuery, this.institutionId, pageNo, this.showSearch ? 20 : 5, this.futureOnly, this.sortField, this.sortDirection).subscribe((result) => {
        this.items = result.results;
        this.pagerService.refreshInstances(this.pagerInstance, this.pageNo, result.totalResults, pageSize);
        this.changeDetectorRef.detectChanges();
     });
  }
  getDate() { return new Date(); }
}
