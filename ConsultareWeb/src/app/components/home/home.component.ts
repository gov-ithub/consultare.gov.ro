import { Component, OnInit } from '@angular/core';
import { ProposalsService } from '../../services/index';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private proposalsService: ProposalsService) { }

  private items:any = [];
  ngOnInit() {
      this.proposalsService.getDocuments().subscribe((result)=>{
        this.items = result;
      })
  }

}
