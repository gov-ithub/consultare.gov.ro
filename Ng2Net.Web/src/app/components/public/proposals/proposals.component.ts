import { Component, OnInit } from '@angular/core';
import { ProposalsService, InstitutionService } from '../../../services';

@Component({
  selector: 'app-proposals',
  templateUrl: './proposals.component.html',
  styleUrls: ['./proposals.component.css']
})
export class ProposalsComponent implements OnInit {

  private institutions: any[];
  private items: any = [];
  private filterQuery: string = '';
  constructor(private proposalsService: ProposalsService,
    private institutionService: InstitutionService
) { }

  ngOnInit() {
    this.refreshData(0);
    this.institutionService.getInstitutions().subscribe(result => {this.institutions = result;});

  }

  refreshData(pageNo: number)
  { console.log(this.filterQuery);
      this.proposalsService.getDocuments(this.filterQuery, pageNo, 10).subscribe((result) => {
        this.items = result;
      });
  }

}
