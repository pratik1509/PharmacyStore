import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WholeSellerComponent } from './wholeSeller.component';

describe('WholeSellerComponent', () => {
  let component: WholeSellerComponent;
  let fixture: ComponentFixture<WholeSellerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WholeSellerComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WholeSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
