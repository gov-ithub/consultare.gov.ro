import { Component, OnInit } from '@angular/core';
import { InstitutionService, HttpClient } from '../../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { InstitutionEditComponent } from '../../';

@Component({
  selector: 'app-institution-list',
  templateUrl: './institution-list.component.html',
  styleUrls: ['./institution-list.component.css']
})
export class InstitutionListComponent implements OnInit {

  private institutions: any[] = [];
  private filterQuery: string = '';

  constructor(private activeModal: NgbActiveModal, private modalService: NgbModal, private institutionService: InstitutionService, private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.institutionService.listInstitutions(this.filterQuery, 0, 50).subscribe(result => this.institutions = result);
  }

  openEdit(instituion: any) {
    let modal = this.modalService.open(InstitutionEditComponent, { size: 'lg', keyboard: false });
    modal.componentInstance.instituion = instituion;
    modal.componentInstance.parentComponent = this;
  }

  delete(instituion: any) {
    if (confirm('Are you sure?')) {
    this.institutionService.deleteInstitution(instituion.id).subscribe(() => this.refresh());
    }
  }
}
