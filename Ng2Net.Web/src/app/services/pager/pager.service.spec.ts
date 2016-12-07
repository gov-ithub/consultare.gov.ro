/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PagerService } from './pager.service';

describe('Service: Pager', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PagerService]
    });
  });

  it('should ...', inject([PagerService], (service: PagerService) => {
    expect(service).toBeTruthy();
  }));
});
