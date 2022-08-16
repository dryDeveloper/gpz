import { TestBed } from '@angular/core/testing';

import { RepeatedSolicitudesService } from './repeated-solicitudes.service';

describe('RepeatedSolicitudesService', () => {
  let service: RepeatedSolicitudesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RepeatedSolicitudesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
