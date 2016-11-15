/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProposalsService } from './proposals.service';

describe('Service: Proposals', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProposalsService]
    });
  });

  it('should ...', inject([ProposalsService], (service: ProposalsService) => {
    expect(service).toBeTruthy();
  }));
});
