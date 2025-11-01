import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { MatFormField, MatError, MatHint, FloatLabelType } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatStepper, MatStep, MatStepperPrevious, MatStepperNext } from '@angular/material/stepper';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RegisterResponse } from '../../../shared/models/RegisterResponse';
import { MatIcon } from "@angular/material/icon";


@Component({
  standalone: true,
  selector: 'app-wizard-register',
  imports: [ReactiveFormsModule, MatStepper, MatStep, MatFormField, MatInput, MatStepperPrevious, MatStepperNext, MatError, MatIcon, MatHint],
  templateUrl: './wizard-register.html',
  styleUrl: './wizard-register.scss',
})
export class WizardRegister {
  http = inject(HttpClient);
  registerForm: FormGroup;
  showPassword: boolean = false;
  messageStrength: string = "";
  showPassMessage: boolean = true;
  showPassError: boolean = false;
  floatLabelAttribute: FloatLabelType = 'auto';

  //add reference #password for input element 
  @ViewChild('password') password!: ElementRef;
  @ViewChild('visibilityIcon') visibilityIcon!: ElementRef;
  @ViewChild('strengthBar') strengthBar!: ElementRef;
  @ViewChild('strengthMessage') strengthMessage!: ElementRef;


  parameters = {
    count: false,
    uppercase: false,
    numbers: false,
    special: false,
  }


  constructor(private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      line1: ['', [Validators.required]],
      line2: [''],
      city: ['', [Validators.required]],
      country: ['', [Validators.required]],
      confirmedPassword: ['', [Validators.required, this.matchValuesCustom('password')]],
      fingerPrint: ['']
    });
  }
  matchValuesCustom(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      const formGroup = control.parent as FormGroup;
      if (!formGroup) return null;

      const matchingValue = formGroup.get(matchTo)?.value;
      return control.value === matchingValue ? null : { passwordMismatch: true }; //there can be written anything that describes error (not just passwordMismatch)
    }
  }

  get isFirstStepValid() {
    return this.registerForm.get('firstName')?.valid && this.registerForm.get('lastName')?.valid;
  }
  get isSecondStepValid() {
    return this.registerForm.get('email')?.valid && this.registerForm.get('password')?.valid && this.registerForm.get('confirmedPassword')?.valid;
  }
  get isThirdStepValid() {
    return this.registerForm.get('line1')?.valid && this.registerForm.get('city')?.valid && this.registerForm.get('country')?.valid;
  }

  onRegister() {
    console.log("Submit button clicked");
    const formData = this.registerForm.value;
    delete formData.confirmedPassword;
    console.log(formData);

    this.http.post<RegisterResponse>("https://localhost:7260/api/auth/register", formData, { headers: { 'Accept': 'text/plain' } }).subscribe({
      next: (result) => {
        alert("Uspješno ste se registrovali");
        this.registerForm.reset();
        this.handleRegisterSuccess(result);
      },
      error: (error) => {
        console.log(error.error.message);
      }
    });
  }

  handleRegisterSuccess(result: RegisterResponse) {
    sessionStorage.setItem('accessToken', result.accessToken || '');
    sessionStorage.setItem('refreshToken', result.refreshToken || '');
    sessionStorage.setItem('expiresAt', result.expiresAtUtc?.toString() || '');
    sessionStorage.setItem('userId', result.userId.toString());
  }
  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;

    const passwordElement = this.password?.nativeElement;
    const visibilityIcon = this.visibilityIcon?.nativeElement;

    if (passwordElement) {
      passwordElement.type = this.showPassword ? 'text' : 'password';
      visibilityIcon.style.color = this.showPassword ? "#3498db" : "#808080";
    }
  }
  strengthChecker() {
    let baseMessage = "Jačina lozinke: ";
    let strengthBar = this.strengthBar?.nativeElement;
    let strengthLevel = "Prekratka";

    let password = this.password?.nativeElement.value;
    let rule1 = /[A-Z]/;
    let rule2 = /[\d]/;
    let rule3 = /[!@#$%^&*(),.?":{}|<>]/;


    this.parameters.uppercase = (rule1.test(password));
    this.parameters.numbers = (rule2.test(password));
    this.parameters.special = (rule3.test(password));
    this.parameters.count = (password.length >= 6) ? true : false;

    let barLength = Object.values(this.parameters).filter(value => value);

    const levels = {
      0: { width: '10%', color: '#d32f2f', message: 'prekratka' },
      1: { width: '25%', color: '#ff6666', message: 'veoma slaba' },
      2: { width: '50%', color: '#ff691f', message: 'slaba' },
      3: { width: '75%', color: '#ffda36', message: 'dovoljna' },
      4: { width: 'auto', color: '#0be881', message: 'jaka' },
    }

    const config = levels[barLength.length as keyof typeof levels];

    if (barLength.length == 0) {
      this.floatLabelAttribute = 'auto';
    }
    else {
      this.floatLabelAttribute = 'always';
    }
    this.messageStrength = baseMessage;
    this.messageStrength += config.message;

    strengthBar.style.setProperty('width', config.width, 'important');
    strengthBar.style.setProperty('background-color', config.color, 'important');
    if (barLength.length < 4)
      strengthBar.style.setProperty('border-radius', '0 0 0px 4px', 'important')
    else {
      strengthBar.style.setProperty('border-radius', '0 0 4px 4px', 'important');
    }

  }
}