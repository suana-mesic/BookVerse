import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, inject, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { CaptchaInputComponent } from '../../shared/components/captcha-input/captcha-input.component';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { RegisterCommandDto } from '../../../api-services/auth/auth-api.model';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CountriesApiService } from '../../../api-services/rest-countries/countires-api.service';
import { environment } from '../../../../environments/environment';
import {
  applyFieldErrorsToForm,
  clearServerErrors,
  extractFieldErrors,
} from '../../../core/services/field-errors.helper';
import { getBusinessRuleMessage } from '../../../core/services/business-rule-error.helper';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit {
  http = inject(HttpClient);
  fb = inject(FormBuilder);
  showPassword: boolean = false;
  messageStrength: string = '';
  showPassMessage: boolean = true;
  showPassError: boolean = false;
  floatLabelAttribute: FloatLabelType = 'auto';
  invisible: boolean = true;
  confirmInvisible: boolean = true;
  countriesService = inject(CountriesApiService);
  dialogHelper = inject(DialogHelperService);
  router = inject(Router);
  translate = inject(TranslateService);

  // Banner shown at the top of the form when the server rejects the submit
  // (CAPTCHA_INVALID, network error, etc.). Null = banner hidden.
  registerErrorMessage: string | null = null;

  countries: { name: string; countryCode: string; nameBs: string }[] = [];
  cities: string[] = [];
  loadingCities = false;

  @ViewChild('password') password!: ElementRef;
  @ViewChild('visibilityIcon') visibilityIcon!: ElementRef;
  @ViewChild('strengthBar') strengthBar!: ElementRef;
  @ViewChild('strengthMessage') strengthMessage!: ElementRef;
  @ViewChild('confirmedPasswordInput') confirmedPasswordInput!: ElementRef;

  // Reference to the captcha widget. We read (token, answer) from it at submit time
  // and call refresh() if the server rejects the registration.
  @ViewChild('captcha') captcha?: CaptchaInputComponent;

  parameters = {
    count: false,
    uppercase: false,
    numbers: false,
    special: false,
  };

  registerForm = this.fb.group({
    firstName: ['', [Validators.required, Validators.minLength(2)]],
    lastName: ['', [Validators.required, Validators.minLength(2)]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    line1: ['', [Validators.required]],
    line2: [''],
    city: [{ value: '', disabled: true }, [Validators.required]],
    country: [
      null as { name: string; countryCode: string; nameBs: string } | null,
      [Validators.required],
    ],
    confirmedPassword: ['', [Validators.required, this.matchValuesCustom('password')]],
    fingerPrint: [''],
  });

  ngOnInit(): void {
    this.fetchCountriesFromApi();
    this.translate.onLangChange.subscribe(() => {
      this.fetchCountriesFromApi();
      this.registerForm.get('city')?.reset();
      this.registerForm.get('country')?.reset();
      this.cities = [];
    });
  }

  private fetchCountriesFromApi() {
    this.countriesService.getCountries().subscribe((countries) => {
      this.countries = countries;
    });
  }

  public onCountryChange(country: { name: string; countryCode: string }) {
    this.registerForm.get('city')?.reset();
    this.registerForm.get('city')?.disable();
    this.cities = [];

    if (country) {
      this.loadingCities = true;
      this.countriesService.getCitiesByCountry(country.countryCode).subscribe({
        next: (cities) => {
          this.cities = cities;
          this.loadingCities = false;
          this.registerForm.get('city')?.enable();
        },
        error: () => (this.loadingCities = false),
      });
    }
  }

  matchValuesCustom(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      const formGroup = control.parent as FormGroup;
      if (!formGroup) return null;
      const matchingValue = formGroup.get(matchTo)?.value;
      return control.value === matchingValue ? null : { passwordMismatch: true };
    };
  }

  get isFirstStepValid() {
    return this.registerForm.get('firstName')?.valid && this.registerForm.get('lastName')?.valid;
  }

  get isSecondStepValid() {
    return (
      this.registerForm.get('email')?.valid &&
      this.registerForm.get('password')?.valid &&
      this.registerForm.get('confirmedPassword')?.valid
    );
  }

  get isThirdStepValid() {
    return (
      this.registerForm.get('line1')?.valid &&
      this.registerForm.get('city')?.valid &&
      this.registerForm.get('country')?.valid
    );
  }

  onRegister() {
    // Don't submit if the captcha widget hasn't loaded yet or the user hasn't filled in
    // a 5-character answer. The backend will reject the request anyway, so we save a round trip.
    if (!this.captcha?.isValid) return;

    // Clear stale errors from the previous attempt: per-field server errors AND the
    // top-of-form banner. If the new attempt fails, the error handler sets them again.
    clearServerErrors(this.registerForm);
    this.registerErrorMessage = null;

    const formData = this.registerForm.value;

    // Pull the (token, answer) pair from the shared captcha widget and add it to the request.
    // The backend re-verifies them in RegisterCommandHandler before creating the user.
    const captchaValue = this.captcha.getValue();

    const payload = {
      ...formData,
      country: formData.country?.nameBs ?? '',
      captchaToken: captchaValue.token,
      captchaAnswer: captchaValue.answer,
    };
    delete payload.confirmedPassword;
    // console.log(payload);

    this.http
      .post<RegisterCommandDto>(`${environment.apiUrl}/api/auth/register`, payload, {
        headers: { Accept: 'text/plain' },
      })
      .subscribe({
        next: (result) => {
          this.registerForm.reset();
          this.handleRegisterSuccess(result);
          this.showMessage();
          this.router.navigate(['/auth/login']);
        },
        error: (error) => {
          // Refresh the captcha so the user gets a fresh challenge after any failure.
          this.captcha?.refresh();

          // CAPTCHA_INVALID (and any other business-rule code) shows up in the red
          // banner at the top of the form, with its OWN localized message.
          const businessRuleMsg = getBusinessRuleMessage(error, this.translate);
          if (businessRuleMsg) {
            this.registerErrorMessage = businessRuleMsg;
            return;
          }

          // Paint per-field validation messages from the backend onto the matching controls.
          // For non-validation errors (409 conflict, network, etc.) nothing is applied and
          // the existing console log remains the only feedback.
          const fieldErrors = extractFieldErrors(error);
          applyFieldErrorsToForm(this.registerForm, fieldErrors);
          console.log(error.error.message);
        },
      });
  }

  /**
   * Returns the server-side error message attached to `controlName`, or null when the field
   * has only client-side errors. The template uses this in each mat-error slot to render the
   * backend's per-field message, falling back to the i18n key when nothing is set.
   */
  serverError(controlName: string): string | null {
    return (this.registerForm.get(controlName)?.errors?.['serverError'] as string) ?? null;
  }

  private showMessage() {
    this.dialogHelper
      .showSuccess('AUTH.REGISTER.SUCCESS_TITLE', 'AUTH.REGISTER.SUCCESS_MESSAGE')
      .subscribe((result) => {
        if (result && result.button === DialogButton.OK) {
        }
      });
  }

  handleRegisterSuccess(result: RegisterCommandDto) {
    sessionStorage.setItem('accessToken', result.accessToken || '');
    sessionStorage.setItem('refreshToken', result.refreshToken || '');
    sessionStorage.setItem('expiresAt', result.expiresAtUtc?.toString() || '');
    sessionStorage.setItem('userId', result.userId.toString());
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
    this.invisible = !this.invisible;

    const passwordElement = this.password?.nativeElement;
    const visibilityIcon = this.visibilityIcon?.nativeElement;

    if (passwordElement) {
      passwordElement.type = this.showPassword ? 'text' : 'password';
    }
    if (visibilityIcon) {
      visibilityIcon.style.color = this.showPassword ? '#3498db' : '#808080';
    }
  }

  toggleConfirmedPasswordVisibility() {
    this.confirmInvisible = !this.confirmInvisible;
    const input = this.confirmedPasswordInput?.nativeElement;
    if (input) {
      input.type = this.confirmInvisible ? 'password' : 'text';
    }
  }

  strengthChecker() {
    let baseMessage = this.translate.instant('AUTH.REGISTER.STRENGTH_PREFIX');
    let strengthBar = this.strengthBar?.nativeElement;

    let password = this.password?.nativeElement.value;
    let rule1 = /[A-Z]/;
    let rule2 = /[\d]/;
    let rule3 = /[!@#$%^&*(),.?":{}|<>]/;

    this.parameters.uppercase = rule1.test(password);
    this.parameters.numbers = rule2.test(password);
    this.parameters.special = rule3.test(password);
    this.parameters.count = password.length >= 6;

    let barLength = Object.values(this.parameters).filter((value) => value);

    const levels = {
      0: {
        width: '10%',
        color: '#d32f2f',
        message: this.translate.instant('AUTH.REGISTER.STRENGTH_TOO_SHORT'),
      },
      1: {
        width: '25%',
        color: '#ff6666',
        message: this.translate.instant('AUTH.REGISTER.STRENGTH_VERY_WEAK'),
      },
      2: {
        width: '50%',
        color: '#ff691f',
        message: this.translate.instant('AUTH.REGISTER.STRENGTH_WEAK'),
      },
      3: {
        width: '75%',
        color: '#ffda36',
        message: this.translate.instant('AUTH.REGISTER.STRENGTH_FAIR'),
      },
      4: {
        width: 'auto',
        color: '#0be881',
        message: this.translate.instant('AUTH.REGISTER.STRENGTH_STRONG'),
      },
    };

    const config = levels[barLength.length as keyof typeof levels];

    this.floatLabelAttribute = barLength.length == 0 ? 'auto' : 'always';
    this.messageStrength = baseMessage + config.message;

    strengthBar.style.setProperty('width', config.width, 'important');
    strengthBar.style.setProperty('background-color', config.color, 'important');
    strengthBar.style.setProperty(
      'border-radius',
      barLength.length < 4 ? '0 0 0px 4px' : '0 0 4px 4px',
      'important',
    );
  }
}
