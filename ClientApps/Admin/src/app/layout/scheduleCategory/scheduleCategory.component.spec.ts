import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleCategoryComponent } from './scheduleCategory.component';

describe('ScheduleCategoryComponent', () => {
  let component: ScheduleCategoryComponent;
  let fixture: ComponentFixture<ScheduleCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ScheduleCategoryComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScheduleCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
