import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-html-page',
  templateUrl: './html-page.component.html',
  styleUrls: ['./html-page.component.css']
})
export class HtmlPageComponent implements OnInit {

  private contentName: string;

  constructor (private contentService: ContentService, private route: ActivatedRoute ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.contentService.getHtmlContentByUrl(params['url']).subscribe(result => { this.contentName = result.name; }); 
    });
  }

}
