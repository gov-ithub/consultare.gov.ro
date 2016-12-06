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
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(private activeModal: NgbActiveModal, private institutionService: InstitutionService ) { }

  ngOnInit() {
  }

  save() {
    if (!this.myForm.valid) {
      return;
    }
    this.institutionService.saveInstitution(this.institution).subscribe(result => {
      this.institution = result;
      this.result = 'Informatiile au fost salvate';
      this.parentComponent.refresh(); });
  }
}
