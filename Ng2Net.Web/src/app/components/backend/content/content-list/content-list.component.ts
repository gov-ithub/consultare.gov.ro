import { Component, OnInit } from '@angular/core';
import { ContentService, HttpClient } from '../../../../services';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ContentEditComponent } from '../../';

@Component({
  selector: 'app-content-list',
  templateUrl: './content-list.component.html',
  styleUrls: ['./content-list.component.css']
})
export class ContentListComponent implements OnInit {

  private htmlContents: any[] = [];
  private filterQuery: string = '';

  constructor(private modalService: NgbModal, private contentService: ContentService, private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.contentService.listHtmlContents(this.filterQuery).subscribe(result => this.htmlContents = result);
  }

  openEdit(htmlContent: any) {
    let modal = this.modalService.open(ContentEditComponent, { size: 'lg', keyboard: false });
    modal.componentInstance.htmlContent = htmlContent;
    modal.componentInstance.parentComponent = this;
  }

  delete(htmlContent: any) {
    if (confirm('Are you sure?')) {
    this.contentService.deleteHtmlContent(htmlContent.id).subscribe(() => this.refresh());
    }
  }
}
