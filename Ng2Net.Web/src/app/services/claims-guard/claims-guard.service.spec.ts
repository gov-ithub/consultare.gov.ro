/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ClaimsGuardService } from './claims-guard.service';

describe('Service: ClaimsGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ClaimsGuardService]
    });
  });

  it('should ...', inject([ClaimsGuardService], (service: ClaimsGuardService) => {
    expect(service).toBeTruthy();
  }));
});
