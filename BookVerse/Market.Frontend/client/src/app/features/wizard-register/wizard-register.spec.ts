import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WizardRegister } from './wizard-register';

describe('WizardRegister', () => {
  let component: WizardRegister;
  let fixture: ComponentFixture<WizardRegister>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WizardRegister]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WizardRegister);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
