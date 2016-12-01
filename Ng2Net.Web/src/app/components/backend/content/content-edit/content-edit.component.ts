import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ContentService } from '../../../../services';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-content-edit',
  templateUrl: './content-edit.component.html',
  styleUrls: ['./content-edit.component.css']
})
export class ContentEditComponent implements OnInit {

  @Input()
  private htmlContent: any = {};
  private parentComponent: any = {};
  private result: string;
  private editMode: string = "HTML";
  @ViewChild('myForm')
  private myForm: NgForm;

  constructor(private activeModal: NgbActiveModal, private contentService: ContentService ) { }

  ngOnInit() {
  }

  save() {
    if (!this.myForm.valid) {
      return;
    }
    this.contentService.saveHtmlContent(this.htmlContent).subscribe(result => {
      this.htmlContent = result;
      this.result = 'Informatiile au fost salvate';
      this.parentComponent.refresh(); });
  }
}
