// products.component.ts

import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  ListBooksRequest,
  ListBooksQueryDto,
} from '../../../../api-services/books/books-api.models';
import { BaseListPagedComponent } from '../../../../core/components/base-classes/base-list-paged-component';
import { ToasterService } from '../../../../core/services/toaster.service';
import { DialogHelperService } from '../../../shared/services/dialog-helper.service';
import { DialogButton } from '../../../shared/models/dialog-config.model';
import { BooksApiService } from '../../../../api-services/books/books-api.service';

@Component({
  selector: 'app-products',
  standalone: false,
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss',
})
export class BooksComponent
  extends BaseListPagedComponent<ListBooksQueryDto, ListBooksRequest>
  implements OnInit
{
  private api = inject(BooksApiService);
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private dialogHelper = inject(DialogHelperService);

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
      error: (err) => {
        this.stopLoading('Failed to load products');
        console.error('Load products error:', err);
      },
    });
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

  onSearch(): void {
    this.request.paging.page = 1;
    this.loadPagedData();
  }
}
