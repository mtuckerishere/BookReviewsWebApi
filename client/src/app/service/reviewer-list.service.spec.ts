import { TestBed } from '@angular/core/testing';

import { ReviewerListService } from './reviewer-list.service';

describe('ReviewerListService', () => {
  let service: ReviewerListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReviewerListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
