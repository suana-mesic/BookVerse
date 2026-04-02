import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ListUsersQueryDto, ListUsersRequest } from '../../../api-services/users/users-api.model';
import { BaseListPagedComponent } from '../../core/components/base-classes/base-list-paged-component';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { ToasterService } from '../../core/services/toaster.service';

@Component({
  selector: 'app-users',
  standalone: false,
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent
  extends BaseListPagedComponent<ListUsersQueryDto, ListUsersRequest>
  implements OnInit
{
  private api = inject(UsersApiService);
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private route = inject(ActivatedRoute);

  displayedColumns = ['fullName', 'email', 'roles', 'isEnabled', 'actions'];

  constructor() {
    super();
    this.request = new ListUsersRequest();
    this.request.paging.pageSize = 20;
  }

  ngOnInit(): void {
    this.initList();
  }

  protected loadPagedData(): void {
    this.startLoading();
    this.api.list(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: () => this.stopLoading('Greška pri učitavanju korisnika'),
    });
  }

  onEdit(user: ListUsersQueryDto): void {
    this.router.navigate(['edit', user.id], { relativeTo: this.route });
  }
}
