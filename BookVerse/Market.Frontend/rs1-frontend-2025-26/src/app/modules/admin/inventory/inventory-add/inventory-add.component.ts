import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {ListBooksQueryDto, ListBooksRequest } from '../../../../api-services/books/books-api.models';
import { ToasterService } from '../../../../core/services/toaster.service';
import { BooksApiService } from '../../../../api-services/books/books-api.service';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { InventoryApiService } from '../../../../api-services/inventory/inventory-api.service';
import { GetInventoryByIdQueryDto, StoreBookPairs } from '../../../../api-services/inventory/inventory-api.model';
import { ListStoresQueryDto, ListStoresRequest } from '../../../../api-services/stores/stores-api.model';
import { StoresApiService } from '../../../../api-services/stores/stores-api.service';
@Component({
  selector: 'app-products-edit',
  standalone: false,
  templateUrl: './inventory-add.component.html',
  styleUrl: './inventory-add.component.scss',
  // providers:[BooksFormService]
})
export class InventoryAddComponent
  extends BaseComponent
  implements OnInit {

  private inventoryApi = inject(InventoryApiService);
  private booksApi = inject(BooksApiService);
  private storesApi = inject(StoresApiService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private rotue = inject(ActivatedRoute);
  private toaster = inject(ToasterService);
  private bookId: number = 0;
  private storeId: number = 0;
  private formBuilder = inject(FormBuilder);
  form!:FormGroup;
  
  productId!: number;
  books:ListBooksQueryDto[]=[];
  stores:ListStoresQueryDto[]=[];
  inventory!: GetInventoryByIdQueryDto;
  storeBookPairs!:StoreBookPairs;
  
  ngOnInit(): void {
    this.startLoading();
    this.bookId = +this.route.snapshot.params['bookId'];
    this.storeId = +this.route.snapshot.params['storeId'];
    this.loadForm();
  }
  
  private loadForm(){
    this.loadBooks();
    this.loadStores();
    this.loadStoreBookPairs();
    this.createForm();
  }

  loadStoreBookPairs() {
    this.inventoryApi.getStoreBookPairs().subscribe({
      next:(response) => this.storeBookPairs = response,
      error:(err) => this.toaster.error("Greška prilikom dohvatanja parova prodavnica i knjiga.")
    });
  }

  storeEntires(){
    return Object.entries(this.storeBookPairs || {});
  }

  bookEntries (books: {[bookId:number]:string}){
    return Object.entries(books);
  }
  
  public get inventoryArray():FormArray {
    return this.form.get('inventoryInfo') as FormArray;
  }
  
  private createForm(){
    this.form = this.formBuilder.group({
      inventoryInfo: new FormArray ([
        new FormGroup({
          storeId: new FormControl('', Validators.required),
          bookId: new FormControl('', Validators.required),
          quantityInStock: new FormControl('', Validators.required),
          reorderTreshold: new FormControl('', Validators.required),
          location: new FormControl('',this.validateLocation())
        })
      ])
    });
    this.stopLoading();
  }

  private loadBooks(){
    const request = new ListBooksRequest();
    request.paging.pageSize=10000000;
    this.booksApi.list(request).subscribe({
      next:(response)=>this.books=response.items,
      error:(err)=>this.toaster.error("Greška prilikom dohvatanja knjiga.")
    });
  }

  private loadStores(){
    const request = new ListStoresRequest();
    request.paging.pageSize=10000000;
    this.storesApi.list(request).subscribe({
      next:(response)=>this.stores=response.items,
      error:(err)=>this.toaster.error("Greška prilikom dohvatanja knjiga.")
    });
  }

    dodajNoviInventar() {
    const inventoryGroup = new FormGroup ({
          storeId: new FormControl('', Validators.required),
          bookId: new FormControl('', Validators.required),
          quantityInStock: new FormControl('', Validators.required),
          reorderTreshold: new FormControl('', Validators.required),
          location: new FormControl('', this.validateLocation())
        });
      this.inventoryArray.push(inventoryGroup);
    }

  private validateLocation(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (!control || !control.value || control.value === '')
      return null;
    
    let regexRule = /^Polica [A-Z]-[0-9]{1,}$/;
    return regexRule.test(control.value) ? null : { nevalidnaLokacija: true };
    }
  }

  onSubmit(){
    this.inventoryApi.create(this.form.getRawValue()).subscribe({
      next:(response)=>{
        this.toaster.success("Uspješno ste pohranili novi inventar.");
        this.router.navigate(['/admin/inventory']);
      },
      error:(err)=>this.toaster.error("Greška prilikom pohranjivanja novog inventara."),
    })
  }

}