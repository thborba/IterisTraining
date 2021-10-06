import { TestBed } from '@angular/core/testing';

import { CellListService } from './cell-list.service';

describe('CellListService', () => {
  let service: CellListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CellListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
