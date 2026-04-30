import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';
import { ListUsersQueryDto, ListUsersRequest } from '../../../api-services/users/users-api.model';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { ToasterService } from '../../../core/services/toaster.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-users',
  standalone: false,
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent
  extends BaseListPagedComponent<ListUsersQueryDto, ListUsersRequest>
  implements OnInit, OnDestroy
{
  private api = inject(UsersApiService);
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private route = inject(ActivatedRoute);
  private translate = inject(TranslateService);

  displayedColumns = ['fullName', 'email', 'roles', 'isEnabled', 'actions'];

  private destroy$ = new Subject<void>();
  searchControl = new FormControl('');

  constructor() {
    super();
    this.request = new ListUsersRequest();
    this.request.paging.pageSize = 20;
  }

  ngOnInit(): void {
    this.getPaginationSettings();
    this.initList();
    this.setupSearchDebounce();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private setupSearchDebounce(): void {
    this.searchControl.valueChanges
      .pipe(debounceTime(400), distinctUntilChanged(), takeUntil(this.destroy$))
      .subscribe((searchTerm) => {
        if (!searchTerm || searchTerm.length >= 3) {
          this.request.search = searchTerm || '';
          this.request.paging.page = 1;
          this.loadPagedData();
        }
      });
  }

  protected loadPagedData(): void {
    this.startLoading();
    this.api.list(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: () => this.stopLoading(this.translate.instant('USERS.DIALOGS.ERROR_LOAD')),
    });
  }

  private getPaginationSettings() {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const order = JSON.parse(saved);
      this.request.paging.pageSize = Number(order['defaultPageSize']);
    } else {
      this.request.paging.pageSize = 20;
    }
  }

  onEdit(user: ListUsersQueryDto): void {
    this.router.navigate(['edit', user.id], { relativeTo: this.route });
  }
}
