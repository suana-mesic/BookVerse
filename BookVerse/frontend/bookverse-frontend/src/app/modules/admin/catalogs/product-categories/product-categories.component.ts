import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';
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
import { AuthFacadeService } from '../../../../core/services/auth/auth-facade.service';

@Component({
  selector: 'app-product-categories',
  standalone: false,
  templateUrl: './product-categories.component.html',
  styleUrl: './product-categories.component.scss',
})
export class ProductCategoriesComponent
  extends BaseListPagedComponent<ListProductCategoriesQueryDto, ListProductCategoriesRequest>
  implements OnInit, OnDestroy
{
  private api = inject(ProductCategoriesApiService);
  private dialog = inject(MatDialog);
  private toaster = inject(ToasterService);
  private dialogHelper = inject(DialogHelperService);
  private translate = inject(TranslateService);
  auth = inject(AuthFacadeService);

  displayedColumns: string[] = ['name', 'isEnabled', 'actions'];
  showOnlyEnabledControl = new FormControl<boolean>(false, { nonNullable: true });

  get showOnlyEnabled(): boolean {
    return this.showOnlyEnabledControl.value;
  }

  editingCategoryId: number | null = null;
  inlineEditControl = new FormControl('', [Validators.required, Validators.maxLength(100)]);

  private destroy$ = new Subject<void>();
  searchControl = new FormControl('');

  constructor() {
    super();
    this.request = new ListProductCategoriesRequest();
    this.request.onlyEnabled = false;
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
          this.onSearchChange(searchTerm || '');
        }
      });
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

  private getPaginationSettings() {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const order = JSON.parse(saved);
      this.request.paging.pageSize = Number(order['defaultPageSize']);
    } else {
      this.request.paging.pageSize = 20;
    }
  }

  // === Filters ===

  onSearchChange(searchTerm: string): void {
    this.request.search = searchTerm;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  onToggleEnabledFilter(checked: boolean): void {
    this.showOnlyEnabledControl.setValue(checked, { emitEvent: false });
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
    this.inlineEditControl.setValue(category.name);
    this.inlineEditControl.markAsUntouched();
  }

  cancelEdit(): void {
    this.editingCategoryId = null;
    this.inlineEditControl.reset();
  }

  saveEdit(category: ListProductCategoriesQueryDto) {
    this.inlineEditControl.markAsTouched();

    if (this.inlineEditControl.invalid) {
      return;
    }

    const name = (this.inlineEditControl.value ?? '').trim();

    if (!name || name === category.name) {
      this.cancelEdit();
      return;
    }

    this.api.update(category.id, { name, isEnabled: category.isEnabled }).subscribe({
      next: () => {
        this.toaster.success(this.translate.instant('GENRES.DIALOGS.SUCCESS_UPDATE'));
        this.cancelEdit();
        this.loadPagedData();
      },
      error: (err) => {
        const key = err.status === 409
          ? 'GENRES.DIALOGS.ERROR_DUPLICATE'
          : 'GENRES.DIALOGS.ERROR_UPDATE';
        this.toaster.error(this.translate.instant(key));
        console.error(err);
      },
    });
  }
}
