import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CouponsApiService } from '../../../api-services/coupons/coupons-api.service';
import {
  CreateCouponCommand,
  FormFieldConfig,
} from '../../../api-services/coupons/coupons-api.model';
import { ToasterService } from '../../core/services/toaster.service';
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

  private fieldLabelMap: Record<string, string> = {
    percentOff: 'COUPONS.TYPE_PERCENT',
    amountOff: 'COUPONS.TYPE_AMOUNT',
    name: 'COMMON.NAME',
    promotionCode: 'COUPONS.PROMOTION_CODE',
    startDate: 'COUPONS.START_DATE',
    endDate: 'COUPONS.END_DATE',
    description: 'COMMON.DESCRIPTION',
  };

  getFieldLabel(fieldName: string): string {
    return this.fieldLabelMap[fieldName] ?? fieldName;
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
      group[field.name] = field.required
        ? this.fb.control('', Validators.required)
        : this.fb.control('');
    });
    this.dynamicForm = this.fb.group(group);
  }

  onSubmit(): void {
    if (this.dynamicForm.invalid) return;
    const formData = this.dynamicForm.value;

    const command: CreateCouponCommand = {
      name: formData.name,
      promotionCode: formData.promotionCode,
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
      error: () => {
        this.toaster.error(this.translate.instant('COUPONS.DIALOGS.ERROR_CREATE'));
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
