import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineCommodityComponent } from './medicineCommodity.component';

describe('MedicineCommodityComponent', () => {
  let component: MedicineCommodityComponent;
  let fixture: ComponentFixture<MedicineCommodityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MedicineCommodityComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicineCommodityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
