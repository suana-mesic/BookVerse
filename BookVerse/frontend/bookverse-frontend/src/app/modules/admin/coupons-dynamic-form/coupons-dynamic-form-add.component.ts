import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { merge } from 'rxjs';
import { CouponsApiService } from '../../../api-services/coupons/coupons-api.service';
import {
  CreateCouponCommand,
  FormFieldConfig,
} from '../../../api-services/coupons/coupons-api.model';
import { ToasterService } from '../../../core/services/toaster.service';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-coupons-dynamic-form',
  standalone: false,
  templateUrl: './coupons-dynamic-form-add.component.html',
  styleUrl: './coupons-dynamic-form-add.component.scss',
})
export class CouponsDynamicFormAddComponent {
  private fb = inject(FormBuilder);
  private couponsService = inject(CouponsApiService);
  private toaster = inject(ToasterService);
  private dialogHelper = inject(DialogHelperService);
  private translate = inject(TranslateService);

  selectedType: 'percent' | 'amount' | null = null;
  formFields: FormFieldConfig[] = [];
  dynamicForm: FormGroup = this.fb.group({});
  submitted = false;
  formValues: any = null;

  private readonly fieldLabelMap: Record<string, string> = {
    percentOff: 'COUPONS.PERCENT_OFF',
    amountOff: 'COUPONS.AMOUNT_OFF',
    name: 'COMMON.NAME',
    promotionCode: 'COUPONS.PROMOTION_CODE',
    startDate: 'COUPONS.START_DATE',
    endDate: 'COUPONS.END_DATE',
    description: 'COMMON.DESCRIPTION',
  };

  private readonly fieldMaxLengthMap: Record<string, number> = {
    name: 100,
    promotionCode: 50,
    description: 200,
  };

  getFieldLabel(fieldName: string): string {
    return this.fieldLabelMap[fieldName] ?? fieldName;
  }

  getRequiredError(fieldName: string): string {
    const labelKey = this.fieldLabelMap[fieldName] ?? fieldName;
    const fieldLabel = this.translate.instant(labelKey);
    return this.translate.instant('VALIDATION.REQUIRED_FIELD', { field: fieldLabel });
  }

  getMaxLengthError(fieldName: string): string {
    const max = this.fieldMaxLengthMap[fieldName];
    return this.translate.instant('VALIDATION.MAX_LENGTH', { max });
  }

  onTypeChange(type: 'percent' | 'amount'): void {
    this.selectedType = type;
    this.submitted = false;
    this.formValues = null;

    this.couponsService.getFormConfig(type).subscribe({
      next: (fields) => {
        this.formFields = fields;
        this.buildForm(fields);
      },
    });
  }

  buildForm(fields: FormFieldConfig[]): void {
    const group: any = {};
    fields.forEach((field) => {
      const validators = [];
      if (field.required) validators.push(Validators.required);
      const maxLength = this.fieldMaxLengthMap[field.name];
      if (maxLength) validators.push(Validators.maxLength(maxLength));
      group[field.name] = this.fb.control('', validators);
    });
    this.dynamicForm = this.fb.group(group);
    this.setupDateRangeValidation();
  }

  private setupDateRangeValidation(): void {
    const startCtrl = this.dynamicForm.get('startDate');
    const endCtrl = this.dynamicForm.get('endDate');
    if (!startCtrl || !endCtrl) return;

    merge(startCtrl.valueChanges, endCtrl.valueChanges).subscribe(() => {
      const start = startCtrl.value;
      const end = endCtrl.value;
      if (start && end && new Date(start) >= new Date(end)) {
        endCtrl.setErrors({ ...endCtrl.errors, dateRange: true });
      } else if (endCtrl.hasError('dateRange')) {
        const { dateRange, ...rest } = endCtrl.errors ?? {};
        endCtrl.setErrors(Object.keys(rest).length ? rest : null);
      }
    });
  }

  onSubmit(): void {
    if (this.dynamicForm.invalid) return;
    const formData = this.dynamicForm.value;

    const command: CreateCouponCommand = {
      name: formData.name,
      promotionCode: formData.promotionCode?.toLowerCase(),
      description: formData.description ?? null,
      startDate: this.toDateOnly(formData.startDate),
      endDate: this.toDateOnly(formData.endDate),
      amountOff: this.selectedType == 'amount' ? formData.amountOff : null,
      percentOff: this.selectedType == 'percent' ? formData.percentOff : null,
    };

    this.couponsService.createCoupon(command).subscribe({
      next: () => {
        this.toaster.success(this.translate.instant('COUPONS.DIALOGS.SUCCESS_CREATE'));
        this.clearForm();
      },
      error: (err) => {
        const key = err.status === 409
          ? 'COUPONS.DIALOGS.ERROR_DUPLICATE_CODE'
          : 'COUPONS.DIALOGS.ERROR_CREATE';
        this.toaster.error(this.translate.instant(key));
      },
    });
  }

  clearForm() {
    this.dynamicForm.reset();
    this.formFields = [];
    this.selectedType = null;
    this.submitted = false;
    this.formValues = null;
  }

  private toDateOnly(date: Date): string {
    const d = new Date(date);

    const month = ('0' + (d.getMonth() + 1)).slice(-2);
    const day = ('0' + d.getDate()).slice(-2);

    return `${d.getFullYear()}-${month}-${day}`;
  }
}
