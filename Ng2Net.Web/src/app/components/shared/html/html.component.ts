import { Component, OnInit, Input, NgModule, ViewChild, ViewContainerRef, ComponentRef, OnChanges, Compiler } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ContentService } from '../../../services';
import { ApplicationRoutes } from '../../../app.routes';
import { BackendModule } from '../../backend/backend.module';
import { PublicModule } from '../../public/public.module';

@Component({
  selector: 'app-html',
  templateUrl: './html.component.html',
  styleUrls: ['./html.component.css']
})
export class HtmlComponent implements OnInit, OnChanges {

  @Input('content')
  private content: string;


  @Input('contentName')
  private contentName: string;

  constructor(private contentService: ContentService) { }

  ngOnInit() {}

  ngOnChanges() {
  }

}
