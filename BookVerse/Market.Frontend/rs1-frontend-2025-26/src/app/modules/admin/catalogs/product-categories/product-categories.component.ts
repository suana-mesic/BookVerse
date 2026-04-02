import { Component, inject, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BaseListPagedComponent } from '../../../../core/components/base-classes/base-list-paged-component';
import { ProductCategoriesApiService } from '../../../../api-services/product-categories/product-categories-api.service';
import { ToasterService } from '../../../../core/services/toaster.service';
import { DialogHelperService } from '../../../shared/services/dialog-helper.service';
import { DialogButton } from '../../../shared/models/dialog-config.model';
import { TranslateService } from '@ngx-translate/core';
import {
  ListProductCategoriesRequest,
  ListProductCategoriesQueryDto,
} from '../../../../api-services/product-categories/product-categories-api.model';
import { ProductCategoryUpsertComponent } from './product-category-upsert/product-category-upsert.component';

@Component({
  selector: 'app-product-categories',
  standalone: false,
  templateUrl: './product-categories.component.html',
  styleUrl: './product-categories.component.scss',
})
export class ProductCategoriesComponent
  extends BaseListPagedComponent<ListProductCategoriesQueryDto, ListProductCategoriesRequest>
  implements OnInit
{
  private api = inject(ProductCategoriesApiService);
  private dialog = inject(MatDialog);
  private toaster = inject(ToasterService);
  private dialogHelper = inject(DialogHelperService);
  private translate = inject(TranslateService);

  displayedColumns: string[] = ['name', 'isEnabled', 'actions'];
  showOnlyEnabled = false;

  editingCategoryId: number | null = null;
  editingName: string = '';

  constructor() {
    super();
    this.request = new ListProductCategoriesRequest();
    this.request.onlyEnabled = false;
    this.request.paging.pageSize = 20;
  }

  ngOnInit(): void {
    this.initList();
  }

  protected loadPagedData(): void {
    this.startLoading();

    this.api.listPaged(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading(this.translate.instant('GENRES.DIALOGS.ERROR_LOAD'));
        console.error('Load genres error:', err);
      },
    });
  }

  // === Filters ===

  onSearchChange(searchTerm: string): void {
    this.request.search = searchTerm;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  onToggleEnabledFilter(checked: boolean): void {
    this.showOnlyEnabled = checked;
    this.request.onlyEnabled = checked;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  // === CRUD Actions ===

  onCreate(): void {
    const dialogRef = this.dialog.open(ProductCategoryUpsertComponent, {
      width: '500px',
      maxWidth: '90vw',
      panelClass: 'product-category-dialog',
      autoFocus: true,
      disableClose: false,
      data: {
        mode: 'create',
      },
    });

    dialogRef.afterClosed().subscribe((success: boolean) => {
      if (success) {
        this.dialogHelper.productCategory.showCreateSuccess().subscribe();
        this.loadPagedData();
      }
    });
  }

  onEdit(category: ListProductCategoriesQueryDto): void {
    const dialogRef = this.dialog.open(ProductCategoryUpsertComponent, {
      width: '500px',
      maxWidth: '90vw',
      panelClass: 'product-category-dialog',
      autoFocus: true,
      disableClose: false,
      data: {
        mode: 'edit',
        categoryId: category.id,
      },
    });

    dialogRef.afterClosed().subscribe((success: boolean) => {
      if (success) {
        this.dialogHelper.productCategory.showUpdateSuccess().subscribe();
        this.loadPagedData();
      }
    });
  }

  onDelete(category: ListProductCategoriesQueryDto): void {
    this.dialogHelper.productCategory.confirmDelete(category.name).subscribe((result) => {
      if (result && result.button === DialogButton.DELETE) {
        this.performDelete(category);
      }
    });
  }

  private performDelete(category: ListProductCategoriesQueryDto): void {
    this.startLoading();

    this.api.delete(category.id).subscribe({
      next: () => {
        this.dialogHelper.productCategory.showDeleteSuccess().subscribe();
        this.loadPagedData();
      },
      error: (err) => {
        this.stopLoading();
        const errorMessage = this.extractErrorMessage(err);
        this.dialogHelper
          .showError('DIALOGS.TITLES.ERROR', 'GENRES.DIALOGS.ERROR_DELETE')
          .subscribe();
        console.error('Delete genre error:', err);
      },
    });
  }

  onToggleStatus(category: ListProductCategoriesQueryDto): void {
    this.startLoading();

    const apiAction = category.isEnabled
      ? this.api.disable(category.id)
      : this.api.enable(category.id);

    apiAction.subscribe({
      next: () => {
        const key = category.isEnabled
          ? 'GENRES.DIALOGS.SUCCESS_DISABLE'
          : 'GENRES.DIALOGS.SUCCESS_ENABLE';
        this.toaster.success(this.translate.instant(key, { name: category.name }));
        this.loadPagedData();
      },
      error: (err) => {
        this.stopLoading();
        const errorMessage = this.extractErrorMessage(err);
        if (err.status === 409) {
          this.dialogHelper
            .showWarning('DIALOGS.TITLES.WARNING', errorMessage || 'GENRES.DIALOGS.ERROR_TOGGLE', {
              name: category.name,
            })
            .subscribe();
        } else {
          this.toaster.error(
            errorMessage ||
              this.translate.instant('GENRES.DIALOGS.ERROR_TOGGLE', { name: category.name }),
          );
        }
        console.error('Toggle status error:', err);
        this.loadPagedData();
      },
    });
  }

  private extractErrorMessage(err: any): string | null {
    if (err?.error) {
      if (typeof err.error === 'string') return err.error;
      if (err.error.message) return err.error.message;
      if (err.error.title) return err.error.title;
      if (err.error.errors && typeof err.error.errors === 'object') {
        const errors = Object.values(err.error.errors).flat();
        if (errors.length > 0) return errors.join(', ');
      }
    }
    if (err?.message) return err.message;
    if (err?.statusText && err.statusText !== 'Unknown Error') return err.statusText;
    return null;
  }

  startEdit(category: ListProductCategoriesQueryDto) {
    this.editingCategoryId = category.id;
    this.editingName = category.name;
  }

  cancelEdit(): void {
    this.editingCategoryId = null;
    this.editingName = '';
  }

  saveEdit(category: ListProductCategoriesQueryDto) {
    if (!this.editingName.trim() || this.editingName == category.name) {
      this.cancelEdit();
      return;
    }
    this.api.update(category.id, { name: this.editingName }).subscribe({
      next: () => {
        this.toaster.success(this.translate.instant('GENRES.DIALOGS.SUCCESS_UPDATE'));
        this.cancelEdit();
        this.loadPagedData();
      },
      error: (err) => {
        this.toaster.error(this.translate.instant('GENRES.DIALOGS.ERROR_UPDATE'));
        console.error(err);
      },
    });
  }
}
