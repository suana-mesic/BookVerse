import { Component, Input } from '@angular/core';
import { BaseListPagedComponent } from '../../../../core/components/base-classes/base-list-paged-component';

@Component({
  selector: 'app-bookverse-paginator-bar',
  standalone: false,
  templateUrl: './bookverse-paginator-bar.component.html',
  styleUrl: './bookverse-paginator-bar.component.scss',
})
export class BookversePaginatorBarComponent {
  // ViewModel is any component that extends BaseListPagedComponent
  @Input({ required: true }) vm!: BaseListPagedComponent<any, any>;
  getPageNumbers(): number[] {
    const total = this.vm.totalPages || 1;
    const current = this.vm.request.paging.page;
    const pages: number[] = [];

    if (total <= 7) {
      for (let i = 1; i <= total; i++) pages.push(i);
      return pages;
    }

    pages.push(1);
    if (current > 3) pages.push(-1);
    const start = Math.max(2, current - 1);
    const end = Math.min(total - 1, current + 1);
    for (let i = start; i <= end; i++) pages.push(i);
    if (current < total - 2) pages.push(-1);
    pages.push(total);
    return pages;
  }

  comparePageSize = (a: number, b: number): boolean => {
    return Number(a) === Number(b);
  };
}
