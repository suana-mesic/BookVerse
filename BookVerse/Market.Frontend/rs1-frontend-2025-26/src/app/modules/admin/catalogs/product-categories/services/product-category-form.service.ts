import { Injectable, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {GetProductCategoryByIdQueryDto} from '../../../../../api-services/product-categories/product-categories-api.model';
import { TranslateService } from '@ngx-translate/core';

/**
 * Service for creating and managing product category forms.
 * Used in modal dialog for both create and edit operations.
 */
@Injectable()
export class ProductCategoryFormService {
  private fb = inject(FormBuilder);
  private translate = inject(TranslateService);

  /**
   * Create a product category form with validation.
   * If category data is provided, form is pre-filled (edit mode).
   */
  createCategoryForm(category?: GetProductCategoryByIdQueryDto): FormGroup {
    return this.fb.group({
      name: [
        category?.name ?? '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(100)
        ]
      ]
    });
  }

  /**
   * Get validation error message for a form control.
   */
  getErrorMessage(form: FormGroup, controlName: string): string {
    const control = form.get(controlName);
    if (!control || !control.errors || !control.touched) {
      return '';
    }

    const errors = control.errors;

    if (errors['required']) {
      return this.translate.instant('VALIDATION.REQUIRED');
    }
    if (errors['minlength']) {
      return this.translate.instant('VALIDATION.MIN_LENGTH', { min: errors['minlength'].requiredLength });
    }
    if (errors['maxlength']) {
      return this.translate.instant('VALIDATION.MAX_LENGTH', { max: errors['maxlength'].requiredLength });
    }

    return this.translate.instant('VALIDATION.CUSTOM');
  }
}
