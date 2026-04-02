import { Component, inject, OnInit } from '@angular/core';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../core/components/base-classes/base-component';
import { ToasterService } from '../../core/services/toaster.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-profile',
  standalone: false,
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.scss',
})
export class UserProfileComponent extends BaseComponent implements OnInit {
  private api = inject(UsersApiService);
  private router = inject(Router);
  private fb = inject(FormBuilder);
  private toaster = inject(ToasterService);
  private location = inject(Location);

  profileForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: [{ value: '', disabled: true }],
    line1: ['', Validators.required],
    line2: [''],
    city: ['', Validators.required],
    country: ['', Validators.required],
    twoFactorEnabled: [false],
  });
  ngOnInit(): void {
    this.loadProfile();
  }

  private loadProfile(): void {
    this.startLoading();
    this.api.getMyProfile().subscribe({
      next: (profile) => {
        this.profileForm.patchValue(profile);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading('Greška pri učitavanju profila.');
        console.error(err);
      },
    });
  }
  onSave(): void {
    if (this.profileForm.invalid || this.isLoading) return;

    this.startLoading();

    const payload = {
      firstName: this.profileForm.value.firstName ?? '',
      lastName: this.profileForm.value.lastName ?? '',
      line1: this.profileForm.value.line1 ?? '',
      line2: this.profileForm.value.line2 ?? '',
      city: this.profileForm.value.city ?? '',
      country: this.profileForm.value.country ?? '',
      twoFactorEnabled: this.profileForm.value.twoFactorEnabled ?? false,
    };

    this.api.updateMyProfile(payload).subscribe({
      next: () => {
        this.stopLoading();
        this.toaster.success('Uspješno ste ažurirali profil');
      },
      error: (err) => {
        this.stopLoading('Greška pri snimanju profila.');
        console.error(err);
      },
    });
  }

  goBack(): void {
    this.location.back();
  }
}
