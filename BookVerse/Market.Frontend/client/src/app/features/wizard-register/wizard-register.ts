import { Component, inject } from '@angular/core';
import { MatFormField, MatError } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatStepper, MatStep, MatStepperPrevious, MatStepperNext, MatStepLabel } from '@angular/material/stepper';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RegisterResponse } from '../../shared/models/RegisterResponse';

@Component({
  standalone: true,
  selector: 'app-wizard-register',
  imports: [ReactiveFormsModule, MatStepper, MatStep, MatFormField, MatInput, MatStepperPrevious, MatStepperNext, MatError],
  templateUrl: './wizard-register.html',
  styleUrl: './wizard-register.scss',
})
export class WizardRegister {
  registerForm: FormGroup;
  http = inject(HttpClient);

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
}