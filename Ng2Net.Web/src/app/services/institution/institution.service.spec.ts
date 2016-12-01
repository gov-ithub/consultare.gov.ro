/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InstitutionService } from './institution.service';

describe('Service: Institution', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InstitutionService]
    });
  });

  it('should ...', inject([InstitutionService], (service: InstitutionService) => {
    expect(service).toBeTruthy();
  }));
});
