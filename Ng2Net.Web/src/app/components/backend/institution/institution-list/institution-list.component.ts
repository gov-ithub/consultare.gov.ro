import { Component, OnInit } from '@angular/core';
import { InstitutionService, HttpClient, PagerService } from '../../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { InstitutionEditComponent } from '../../';

@Component({
  selector: 'app-institution-list',
  templateUrl: './institution-list.component.html',
  styleUrls: ['./institution-list.component.css']
})
export class InstitutionListComponent implements OnInit {

  private institutions: any[] = [];
  private filterQuery: string = '';
  private pagerInstance='proposals.component';

  constructor(private modalService: NgbModal, private institutionService: InstitutionService, private http: HttpClient, private pagerService: PagerService) { }

  ngOnInit() {
    this.refresh(0);
  }

  refresh(pageNo: number=0) {
    this.institutionService.listInstitutions(this.filterQuery, pageNo, this.pagerService.defaultPagerConfig.pageSize).subscribe(result => {
      this.institutions = result
      this.pagerService.refreshInstances(this.pagerInstance, pageNo, result.totalResults);
    });
  }

  openEdit(institution: any) {
    let modal = this.modalService.open(InstitutionEditComponent, { size: 'lg', keyboard: false });
    console.log(institution);
    modal.componentInstance.institution = institution;
    modal.componentInstance.parentComponent = this;
  }

  delete(instituion: any) {
    if (confirm('Are you sure?')) {
    this.institutionService.deleteInstitution(instituion.id).subscribe(() => this.refresh(0));
    }
  }
}
