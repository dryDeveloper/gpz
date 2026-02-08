import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditRequestStats } from './credit-request-stats';

describe('CreditRequestStats', () => {
  let component: CreditRequestStats;
  let fixture: ComponentFixture<CreditRequestStats>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreditRequestStats]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreditRequestStats);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
