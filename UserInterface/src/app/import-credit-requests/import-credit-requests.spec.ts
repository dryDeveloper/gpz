import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportCreditRequests } from './import-credit-requests';

describe('ImportCreditRequests', () => {
  let component: ImportCreditRequests;
  let fixture: ComponentFixture<ImportCreditRequests>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImportCreditRequests]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImportCreditRequests);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
