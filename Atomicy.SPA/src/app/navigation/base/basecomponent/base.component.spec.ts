import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasecomponentComponent } from './base.component';

describe('BasecomponentComponent', () => {
  let component: BasecomponentComponent;
  let fixture: ComponentFixture<BasecomponentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BasecomponentComponent]
    });
    fixture = TestBed.createComponent(BasecomponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
