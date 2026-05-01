import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { ToasterService } from '../../../core/services/toaster.service';
import { Location } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import { CountriesApiService } from '../../../api-services/rest-countries/countires-api.service';
import { Subscription } from 'rxjs';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';

@Component({
  selector: 'app-user-profile',
  standalone: false,
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss',
})
export class UserProfileComponent extends BaseComponent implements OnInit, OnDestroy {
  private api = inject(UsersApiService);
  private router = inject(Router);
  private fb = inject(FormBuilder);
  private toaster = inject(ToasterService);
  private location = inject(Location);
  private translate = inject(TranslateService);
  private countriesService = inject(CountriesApiService);
  private authFacade = inject(AuthFacadeService);

  countries: { name: string; countryCode: string; nameBs: string }[] = [];
  cities: string[] = [];
  loadingCities = false;

  private langSub?: Subscription;

  profileForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: [{ value: '', disabled: true }],
    line1: ['', Validators.required],
    line2: [''],
    city: [{ value: '' as string | null, disabled: true }, Validators.required],
    country: [
      null as { name: string; countryCode: string; nameBs: string } | null,
      Validators.required,
    ],
    twoFactorEnabled: [false],
  });

  ngOnInit(): void {
    this.loadCountriesAndProfile();

    this.langSub = this.translate.onLangChange.subscribe(() => {
      const current = this.profileForm.value.country;
      const selectedNameBs = current?.nameBs ?? null;

      this.countriesService.getCountries().subscribe((countries) => {
        this.countries = countries;
        if (selectedNameBs) {
          const match = countries.find((c) => c.nameBs === selectedNameBs) ?? null;
          this.profileForm.get('country')?.setValue(match, { emitEvent: false });
        }
      });
    });
  }

  ngOnDestroy(): void {
    this.langSub?.unsubscribe();
  }

  private loadCountriesAndProfile(): void {
    this.startLoading();
    this.countriesService.getCountries().subscribe({
      next: (countries) => {
        this.countries = countries;
        this.loadProfile();
      },
      error: () => {
        this.stopLoading(this.translate.instant('CLIENT.USER_PROFILE.ERROR_LOAD'));
      },
    });
  }

  private loadProfile(): void {
    this.api.getMyProfile().subscribe({
      next: (profile: any) => {
        this.profileForm.patchValue({
          firstName: profile.firstName,
          lastName: profile.lastName,
          email: profile.email,
          line1: profile.line1,
          line2: profile.line2,
          twoFactorEnabled: profile.twoFactorEnabled,
        });

        const matchedCountry = this.countries.find((c) => c.nameBs === profile.country) ?? null;
        this.profileForm.get('country')?.setValue(matchedCountry, { emitEvent: false });

        if (matchedCountry) {
          this.loadCities(matchedCountry.countryCode, profile.city ?? null);
        }

        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading(this.translate.instant('CLIENT.USER_PROFILE.ERROR_LOAD'));
        console.error(err);
      },
    });
  }

  onCountryChange(country: { name: string; countryCode: string; nameBs: string } | null): void {
    this.profileForm.get('city')?.reset();
    this.profileForm.get('city')?.disable();
    this.cities = [];

    if (country) {
      this.loadCities(country.countryCode, null);
    }
  }

  private loadCities(countryCode: string, preselectCity: string | null): void {
    this.loadingCities = true;
    this.countriesService.getCitiesByCountry(countryCode).subscribe({
      next: (cities) => {
        this.cities = cities;
        this.loadingCities = false;
        this.profileForm.get('city')?.enable();
        if (preselectCity) {
          this.profileForm.get('city')?.setValue(preselectCity, { emitEvent: false });
        }
      },
      error: () => (this.loadingCities = false),
    });
  }

  onSave(): void {
    if (this.profileForm.invalid || this.isLoading) return;

    this.startLoading();

    const value = this.profileForm.getRawValue();
    const payload = {
      firstName: value.firstName ?? '',
      lastName: value.lastName ?? '',
      line1: value.line1 ?? '',
      line2: value.line2 ?? '',
      city: value.city ?? '',
      country: value.country?.nameBs ?? '',
      twoFactorEnabled: value.twoFactorEnabled ?? false,
    };

    this.api.updateMyProfile(payload).subscribe({
      next: () => {
        this.stopLoading();
        this.authFacade.updateDisplayName(payload.firstName, payload.lastName);
        this.toaster.success(this.translate.instant('CLIENT.USER_PROFILE.SUCCESS_UPDATE'));
      },
      error: (err) => {
        this.stopLoading(this.translate.instant('CLIENT.USER_PROFILE.ERROR_SAVE'));
        console.error(err);
      },
    });
  }

  compareCountry = (a: { nameBs: string } | null, b: { nameBs: string } | null): boolean =>
    a && b ? a.nameBs === b.nameBs : a === b;

  goBack(): void {
    this.location.back();
  }
}
