import { Component, OnInit } from '@angular/core';
import { ContentService } from '../../../services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private contentService: ContentService) { }

  ngOnInit() {
  }

}
