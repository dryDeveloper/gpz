import { TestBed } from '@angular/core/testing';

import { SpreadsheetToJsonService } from './spreadsheet-to-json.service';

describe('SpreadsheetToJsonService', () => {
  let service: SpreadsheetToJsonService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SpreadsheetToJsonService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
