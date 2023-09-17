import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterfirmComponent } from './registerfirm.component';

describe('RegisterfirmComponent', () => {
  let component: RegisterfirmComponent;
  let fixture: ComponentFixture<RegisterfirmComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegisterfirmComponent]
    });
    fixture = TestBed.createComponent(RegisterfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
