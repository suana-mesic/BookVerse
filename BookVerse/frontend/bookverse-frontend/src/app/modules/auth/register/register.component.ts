import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, inject, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { RegisterCommandDto } from '../../../api-services/auth/auth-api.model';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CountriesApiService } from '../../../api-services/rest-countries/countires-api.service';

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

  countries: { name: string; countryCode: string; nameBs: string }[] = [];
  cities: string[] = [];
  loadingCities = false;

  @ViewChild('password') password!: ElementRef;
  @ViewChild('visibilityIcon') visibilityIcon!: ElementRef;
  @ViewChild('strengthBar') strengthBar!: ElementRef;
  @ViewChild('strengthMessage') strengthMessage!: ElementRef;
  @ViewChild('confirmedPasswordInput') confirmedPasswordInput!: ElementRef;

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
    // console.log('Submit button clicked');
    const formData = this.registerForm.value;

    const payload = {
      ...formData,
      country: formData.country?.nameBs ?? '',
    };
    delete payload.confirmedPassword;
    // console.log(payload);

    this.http
      .post<RegisterCommandDto>('https://localhost:7260/api/auth/register', payload, {
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
          console.log(error.error.message);
        },
      });
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
