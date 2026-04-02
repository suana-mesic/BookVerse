import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { UsersApiService } from '../../../../api-services/users/users-api.service';
import { ToasterService } from '../../../core/services/toaster.service';
import { GetUserByIdQueryDto } from '../../../../api-services/users/users-api.model';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-users-edit',
  standalone: false,
  templateUrl: './users-edit.component.html',
  styleUrl: './users-edit.component.scss',
})
export class UsersEditComponent extends BaseComponent implements OnInit {
  private api = inject(UsersApiService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private fb = inject(FormBuilder);
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);

  userId!: number;
  user: GetUserByIdQueryDto | null = null;

  form = this.fb.group({
    isAdmin: [false],
    isManager: [false],
    isEmployee: [false],
    isEnabled: [true],
  });

  ngOnInit(): void {
    this.userId = +this.route.snapshot.params['userId'];
    this.loadUser();
  }

  private loadUser(): void {
    this.startLoading();
    this.api.getById(this.userId).subscribe({
      next: (user) => {
        this.user = user;
        // Popuni formu sa postojećim vrijednostima
        this.form.patchValue({
          isAdmin: user.isAdmin,
          isManager: user.isManager,
          isEmployee: user.isEmployee,
          isEnabled: user.isEnabled,
        });
        this.stopLoading();
      },
      error: () => {
        this.stopLoading(this.translate.instant('USERS.DIALOGS.NOT_FOUND'));
        this.router.navigate(['/admin/users']);
      },
    });
  }

  save(): void {
    if (this.isLoading) return;
    this.startLoading();

    this.api
      .updateRoles(this.userId, {
        isAdmin: this.form.value.isAdmin!,
        isManager: this.form.value.isManager!,
        isEmployee: this.form.value.isEmployee!,
        isEnabled: this.form.value.isEnabled!,
      })
      .subscribe({
        next: () => {
          this.stopLoading();
          this.toaster.success(this.translate.instant('USERS.DIALOGS.SUCCESS_UPDATE'));
          this.router.navigate(['/admin/users']);
        },
        error: () => this.stopLoading(this.translate.instant('USERS.DIALOGS.ERROR_UPDATE')),
      });
  }

  onCancel(): void {
    this.router.navigate(['/admin/users']);
  }
}
