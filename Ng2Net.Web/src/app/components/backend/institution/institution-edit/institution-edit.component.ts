import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { InstitutionService } from '../../../../services';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-institution-edit',
  templateUrl: './institution-edit.component.html',
  styleUrls: ['./institution-edit.component.css']
})
export class InstitutionEditComponent implements OnInit {

  @Input()
  private institution: any = {};
  private parentComponent: any = {};
  private result: string;
  private editMode: string = "HTML";
  @ViewChild('instForm')
  private instForm: NgForm;
  private institutions: any[] = [];
  private deleteInstitution: boolean = false;
  private destInstitutionId: string;

  constructor(private activeModal: NgbActiveModal, private institutionService: InstitutionService ) { }

  ngOnInit() {
  }

  confirmDelete() {
    this.institutionService.getInstitutions().subscribe(result => { this.institutions = result.filter(x=>x.id!=this.institution.id); this.deleteInstitution=true; });
    
  }
  save() {
    if (!this.instForm.valid) {
      return;
    }
    this.institutionService.saveInstitution(this.institution).subscribe(result => {
      this.institution = result;
      this.result = 'Informatiile au fost salvate';
      this.parentComponent.refresh();
    });
  }

  cancelDelete() {
    this.deleteInstitution = false;
  }

  delete() {
    this.institutionService.deleteInstitution(this.institution.id, this.destInstitutionId).subscribe(() => { this.activeModal.close(); this.parentComponent.refresh() });
  }

}
