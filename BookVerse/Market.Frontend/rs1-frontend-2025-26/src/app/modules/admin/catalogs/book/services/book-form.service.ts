import { Injectable, inject } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { GetBookByIdQueryDto } from '../../../../../api-services/books/books-api.models';
import { TranslateService } from '@ngx-translate/core';

const ISBN_MAX_LENGTH = 20;
const TITLE_MAX_LENGTH = 150;
const LANGUAGE_MAX_LENGTH = 60;

@Injectable()
export class BooksFormService {
  private fb = inject(FormBuilder);
  private translate = inject(TranslateService);

  private readonly fieldLabelKeys: Record<string, string> = {
    isbn: 'BOOKS.FORM.ISBN',
    title: 'BOOKS.FORM.TITLE',
    language: 'BOOKS.FORM.LANGUAGE',
    price: 'BOOKS.FORM.PRICE',
    publisherId: 'BOOKS.FORM.PUBLISHER',
    bookFormatId: 'BOOKS.FORM.FORMAT',
    pageCount: 'BOOKS.FORM.PAGE_COUNT',
    publishedDate: 'BOOKS.FORM.PUBLISHED_DATE',
    categoryIds: 'BOOKS.FORM.CATEGORY',
    authorIds: 'BOOKS.FORM.AUTHOR',
  };

  createProductForm(product?: GetBookByIdQueryDto): FormGroup {
    return this.fb.group({
      isbn: [
        product?.isbn ?? '',
        [Validators.required, Validators.maxLength(ISBN_MAX_LENGTH)],
      ],
      description: [product?.description ?? '', [Validators.maxLength(2000)]],
      title: [
        product?.title ?? '',
        [Validators.required, Validators.maxLength(TITLE_MAX_LENGTH)],
      ],
      price: [
        product?.price ?? null,
        [Validators.required, Validators.min(0.01), Validators.max(1000000)],
      ],
      publisherId: [product?.publisherId ?? null, [Validators.required]],
      bookFormatId: [product?.bookFormatId ?? null, [Validators.required]],
      language: [
        product?.language ?? '',
        [Validators.required, Validators.maxLength(LANGUAGE_MAX_LENGTH)],
      ],
      pageCount: [product?.pageCount ?? null, [Validators.required]],
      quantityInStockForOnlineOrders: [product?.quantityInStockForOnlineOrders ?? null],
      publishedDate: [
        product?.publishedDate ? new Date(product.publishedDate) : null,
        [Validators.required],
      ],
      imageUrl: [product?.imageUrl ?? ''],
      categoryIds: [product?.categoryIds || [], Validators.required],
      authorIds: [product?.authorIds ?? [], Validators.required],
    });
  }

  getErrorMessage(form: FormGroup, controlName: string): string {
    const control = form.get(controlName);
    if (!control || !control.errors || !control.touched) {
      return '';
    }

    const errors = control.errors;
    const labelKey = this.fieldLabelKeys[controlName];
    const fieldName = labelKey ? this.translate.instant(labelKey) : controlName;

    if (errors['required']) {
      return this.translate.instant('VALIDATION.REQUIRED_FIELD', { field: fieldName });
    }
    if (errors['maxlength']) {
      return this.translate.instant('VALIDATION.MAX_LENGTH', {
        max: errors['maxlength'].requiredLength,
      });
    }
    if (errors['min']) {
      return this.translate.instant('VALIDATION.MIN_VALUE', { min: errors['min'].min });
    }
    if (errors['max']) {
      return this.translate.instant('VALIDATION.MAX_VALUE', { max: errors['max'].max });
    }
    if (errors['email']) {
      return this.translate.instant('VALIDATION.EMAIL');
    }

    return this.translate.instant('VALIDATION.CUSTOM');
  }
}
