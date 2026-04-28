// products.component.ts

import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';
import {
  ListBooksRequest,
  ListBooksQueryDto,
} from '../../../../api-services/books/books-api.models';
import { BaseListPagedComponent } from '../../../../core/components/base-classes/base-list-paged-component';
import { ToasterService } from '../../../../core/services/toaster.service';
import { DialogHelperService } from '../../../shared/services/dialog-helper.service';
import { DialogButton } from '../../../shared/models/dialog-config.model';
import { BooksApiService } from '../../../../api-services/books/books-api.service';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';

@Component({
  selector: 'app-products',
  standalone: false,
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss',
})
export class BooksComponent
  extends BaseListPagedComponent<ListBooksQueryDto, ListBooksRequest>
  implements OnInit, OnDestroy
{
  private api = inject(BooksApiService);
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private dialogHelper = inject(DialogHelperService);
  private translate = inject(TranslateService);
  auth = inject(AuthFacadeService);

  private destroy$ = new Subject<void>();
  searchControl = new FormControl('');

  displayedColumns: string[] = [
    'title',
    'categoryName',
    'price',
    'authors',
    'publisherName',
    'format',
    'stockQuantity',
    'isDeleted',
    'actions',
  ];

  constructor() {
    super();
    this.request = new ListBooksRequest();
    this.request.language = this.translate.currentLang || this.translate.defaultLang || 'bs';
    this.request.lookupsOnly = true;
  }

  ngOnInit(): void {
    this.getPaginationSettings();
    this.initList();
    this.setupSearchDebounce();

    this.translate.onLangChange
      .pipe(takeUntil(this.destroy$))
      .subscribe((event: LangChangeEvent) => {
        this.request.language = event.lang;
        this.loadPagedData();
      });
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
      error: (err) => {
        this.stopLoading(this.translate.instant('BOOKS.DIALOGS.ERROR_LOAD'));
        console.error('Load products error:', err);
      },
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

  // === UI Actions ===

  onCreate(): void {
    this.router.navigate(['/admin/products/add']);
  }

  onEdit(product: ListBooksQueryDto): void {
    this.router.navigate(['/admin/products', product.id, 'edit']);
  }

  onDelete(product: ListBooksQueryDto): void {
    this.dialogHelper.product.confirmDelete(product.title).subscribe((result) => {
      if (result && result.button === DialogButton.DELETE) {
        this.performDelete(product);
      }
    });
  }

  private performDelete(product: ListBooksQueryDto): void {
    this.startLoading();

    this.api.delete(product.id).subscribe({
      next: () => {
        this.dialogHelper.product.showDeleteSuccess().subscribe();
        this.loadPagedData();
      },
      error: (err) => {
        this.stopLoading();

        this.dialogHelper
          .showError('DIALOGS.TITLES.ERROR', 'BOOKS.DIALOGS.ERROR_DELETE')
          .subscribe();

        console.error('Delete product error:', err);
      },
    });
  }

}
