import { Component, OnInit } from '@angular/core';
import { ProposalsService } from '../../services/index';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  private items: any = [];

  constructor(private proposalsService: ProposalsService) { }

  ngOnInit() {
      this.proposalsService.getDocuments().subscribe((result) => {
        this.items = result;
      });
  }

}
