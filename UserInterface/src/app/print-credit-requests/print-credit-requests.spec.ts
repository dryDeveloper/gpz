import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCreditRequests } from './print-credit-requests';

describe('PrintCreditRequests', () => {
  let component: PrintCreditRequests;
  let fixture: ComponentFixture<PrintCreditRequests>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrintCreditRequests]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCreditRequests);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
