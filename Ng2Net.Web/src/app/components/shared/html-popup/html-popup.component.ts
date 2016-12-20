import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../../services';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-html-popup',
  templateUrl: './html-popup.component.html',
  styleUrls: ['./html-popup.component.css']
})
export class HtmlPopupComponent implements OnInit {

  public contentName: string;
  public titleName: string;

  constructor (private contentService: ContentService, private route: ActivatedRoute,
  private activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

}
