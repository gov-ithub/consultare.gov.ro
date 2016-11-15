import { Component, OnInit, Input } from '@angular/core';
import { ContentService } from '../../../services';

@Component({
  selector: 'app-html',
  templateUrl: './html.component.html',
  styleUrls: ['./html.component.css']
})
export class HtmlComponent implements OnInit {

  @Input('contentName')
  private contentName: string;

  constructor(private contentService: ContentService) { }

  ngOnInit() {
  }


}
