import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineCategoryComponent } from './medicineCategory.component';

describe('MedicineCategoryComponent', () => {
  let component: MedicineCategoryComponent;
  let fixture: ComponentFixture<MedicineCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MedicineCategoryComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicineCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
