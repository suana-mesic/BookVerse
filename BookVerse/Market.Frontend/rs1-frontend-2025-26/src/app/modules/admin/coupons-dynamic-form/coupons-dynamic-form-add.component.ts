import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CouponsApiService } from '../../../api-services/coupons/coupons-api.service';
import { CreateCouponCommand, FormFieldConfig } from '../../../api-services/coupons/coupons-api.model';
import { ToasterService } from '../../core/services/toaster.service';
import { DialogRef } from '@angular/cdk/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';

@Component({
  selector: 'app-coupons-dynamic-form',
  standalone: false,
  templateUrl: './coupons-dynamic-form-add.component.html',
  styleUrl: './coupons-dynamic-form-add.component.scss',
})
export class CouponsDynamicFormAddComponent  {
  private fb = inject(FormBuilder);
  private couponsService = inject(CouponsApiService);
  private toaster = inject(ToasterService);
  private dialogHelper = inject(DialogHelperService);
  

  selectedType: 'percent' | 'amount' | null = null;
  formFields: FormFieldConfig[] = [];
  dynamicForm: FormGroup = this.fb.group({});
  submitted = false;
  formValues: any = null;

  onTypeChange(type:'percent'|'amount'):void{
    this.selectedType = type;
    this.submitted = false;
    this.formValues = null;

    //dohvatamo konfiguraciju polja sa servera
    this.couponsService.getFormConfig(type).subscribe({
      next:(fields)=>{
        this.formFields = fields;
        this.buildForm(fields);
      }
    });
  }

  buildForm(fields: FormFieldConfig[]):void{
    //Za svako polje koje server vratu kreiramo form control
    //polje dobija validator required ako je required=true
    const group:any = {};
    fields.forEach(field=>{
      group[field.name]=field.required
      ?this.fb.control('',Validators.required)
      :this.fb.control('');
    });

    this.dynamicForm = this.fb.group(group);
  }

  onSubmit():void {
    if (this.dynamicForm.invalid) return;
    const formData = this.dynamicForm.value;

    const command: CreateCouponCommand = {
      name:formData.name,
      promotionCode:formData.promotionCode,
      description:formData.description??null,
      startDate:formData.startDate,
      endDate:formData.endDate,
      amountOff:this.selectedType=='amount'?formData.amountOff:null,
      percentOff:this.selectedType=='percent'?formData.percentOff:null
    };

    this.couponsService.createCoupon(command).subscribe({
      next:(response)=>{
        this.toaster.success("Uspješno šte kreirali novi kupon");
        this.clearForm();
      },
      error:(err)=>{
        this.toaster.error("Greška prilikom kreiranja novog kupona");
      }
    });
  }

  clearForm() {
    this.dynamicForm.reset();
    this.formFields = [];
    this.selectedType = null;
    this.submitted = false;
    this.formValues = null;
  }
}
