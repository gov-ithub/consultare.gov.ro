import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { PagerService, PagerConfig } from '../../../services';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {

  @Input()
  private config: PagerConfig;
  @Input()
  private instance: string;
  @Input()
  private extraClass: string;

  private startPage: number;
  private endPage: number;
  private pageArray: number[] = [];

  @Output()
  private onPageChange = new EventEmitter(false);

  constructor(private pagerService: PagerService) {
  }

  ngOnInit() {
    if (!this.instance)
      throw "You need to set the instance name for the pager control ( instance='instance_name' )";
    this.config = this.pagerService.registerInstance(this.instance, this);

    this.populatePager();
  }

  populatePager() {
    this.pageArray=[];
    this.config.totalPages = Math.ceil(this.config.totalResults/this.config.pageSize);
    this.startPage = this.config.pageNo<((this.config.showPages-1)/2) ? 0 : this.config.pageNo>this.config.totalPages-((this.config.showPages+1)/2) ? this.config.totalPages-this.config.showPages : this.config.pageNo - Math.floor((this.config.showPages-1)/2);
    this.endPage = this.config.pageNo>this.config.totalPages-((this.config.showPages+1)/2) ? this.config.totalPages : this.config.pageNo<((this.config.showPages-1)/2) ? this.config.showPages : this.config.pageNo + Math.floor((this.config.showPages+1)/2);
    if (this.startPage<0) this.startPage=0;
    if (this.endPage>this.config.totalPages) this.endPage = this.config.totalPages-1;
    for(let i=this.startPage; i<this.endPage; i++)
    {
      this.pageArray[this.pageArray.length] = i;
    }
  }

  changePage(pageNumber: number)
  {
    this.config.pageNo = pageNumber;
    this.onPageChange.emit(this.config.pageNo);
  }
}
