import { Injectable } from '@angular/core';
import { PagerConfig } from '../';

@Injectable()
export class PagerService {

  public pagerInstances = [];
  constructor() { }

  public get defaultPagerConfig(): PagerConfig { return new PagerConfig(); }

  registerInstance(instanceName: string, componentInstance: any): any
  {
    if (!this.pagerInstances[instanceName]) {
      this.pagerInstances[instanceName] = {};
      this.pagerInstances[instanceName].config = new PagerConfig();
    }

    this.pagerInstances[instanceName].instances = this.pagerInstances[instanceName].instances || [];
    if (this.pagerInstances[instanceName].instances.indexOf(componentInstance)<0)
      this.pagerInstances[instanceName].instances[this.pagerInstances[instanceName].instances.length] = componentInstance;

    return this.pagerInstances[instanceName].config;
  }

  refreshInstances(instanceName: string, pageNo: number, totalResults: number, pageSize: number = 0)
  {
    if (pageSize === 0)
      pageSize = this.defaultPagerConfig.pageSize;

    if (!this.pagerInstances[instanceName])
      return;
    this.pagerInstances[instanceName].config.pageNo = pageNo;
    this.pagerInstances[instanceName].config.totalResults = totalResults;
    this.pagerInstances[instanceName].config.pageSize = pageSize;

    this.pagerInstances[instanceName].instances.forEach(instance => {
      instance.populatePager(); });
  }

}

