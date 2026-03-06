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
import { map, Observable, startWith } from 'rxjs';
import { B, C } from '@angular/cdk/keycodes';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
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
  private toaster = inject(ToasterService);
  private bookId: number = 0;
  private storeId: number = 0;
  private formBuilder = inject(FormBuilder);
  form!:FormGroup;
  
  books:ListBooksQueryDto[]=[];
  stores:ListStoresQueryDto[]=[];
  inventory!: GetInventoryByIdQueryDto;
  storeBookPairs!:StoreBookPairs;
  
  filteredBookOptions: Observable<[number,string][]>[] = []; //Observable koji "emituje" niz tuple-ova
  filteredStoreOptions:Observable<ListStoresQueryDto[]>[] = [];

  storesAutocompleteInputs = new FormArray<FormControl>([]);
  booksAutocompleteInputs = new FormArray<FormControl>([]);

  ngOnInit(): void {
    this.startLoading();
    this.bookId = +this.route.snapshot.params['bookId'];
    this.storeId = +this.route.snapshot.params['storeId'];
    this.loadForm();
    this.addStoreAutocompleteInput();
    this.addBookAutocompleteInput();
  }

  private loadForm(){
    this.loadBooks();
    this.loadStores();
    this.loadStoreBookPairs();
    this.createForm();
  }

  private setFilteredStoreOptions(): void {
  this.filteredStoreOptions = this.storesAutocompleteInputs.controls.map(
    //index daje informaciju o tome koja se kontrola promijenila (koji input prodavnice)
    (control: FormControl, index:number) =>
      control.valueChanges.pipe(
        startWith(''),
        map(value => this._filterStores(value || '', index))
      )
  );
  }

  private _filterStores(enteredValue: string, index:number):ListStoresQueryDto[]{
    //ima 1 filter
    //filter definiše korisnik -> npr. unese slovo "a" u store autocomplete polju za unos

    const filterValue = enteredValue.toLowerCase();
    const result = this.stores.filter(store=>store.storeName.toLowerCase().includes(filterValue));
    return result;
  }

  clearBookInSameRow(index:number){
    //počistiti autocomplete polje u istom redu gdje se unosi naziv knjige
    this.booksAutocompleteInputs.at(index).setValue('');
  }

  private setFilteredBookOptions(): void {
  this.filteredBookOptions = this.booksAutocompleteInputs.controls.map(
    //index daje informaciju o tome koja se kontrola promijenila (koji input prodavnice)
    (control: FormControl, index:number) =>
      control.valueChanges.pipe(
        startWith(''),
        map(value => this._filterBooks(value || '', index))
      )
  );
  }

  private _filterBooks(enteredValue: string, index:number):[number,string][]{
    //ima 3 filtera
    //1. filter je predodređen -> na osnovu onog kakva je prodavnica odabrana u stores
    //2. filter ispiši samo one knjige koje nisu prethodno selektovane ZA TU PRODAVNICU *
    //3. filter definiše korisnik -> npr. unese slovo "a" u book autocomplete polju za unos

    const filterValue = enteredValue.toLowerCase();
    const storeId = this.inventoryArray.at(index).get('storeId')?.value;

    //filter2 se radi samo ako je za trenutni storeId pronađeno više od 2 knjige u storesAutocompleteInputs
    let applyFilter2: boolean = false;
    const allEnteredStoreIds =  this.storesAutocompleteInputs.controls.map((control)=>control.value)
    const x = allEnteredStoreIds.filter(storeId=>storeId == storeId).length;

    if(x >= 2)
      applyFilter2 = true;

    //ako je storeId = 5, onda this.storeBookPairs[5] će dohvatiti values za ključ storeId = 5, values je [string, int][] -> array tuple-ova
    const filter1 = this.storeBookPairs?.[storeId];
    if(!filter1) return [];

    //iz cijele forme gledamo koji su to odabrani parovi storeId i bookId (šta je to popunjeno na formi)
    const prethodnoOdabraniNaslovi: string[] = this.inventoryArray.controls
    .map((control)=>`${control.get('storeId')?.value} ${control.get('bookId')?.value}`)
    .filter(v => v !== null && v !== undefined);

    if(applyFilter2){
      const filter2 = Object.entries(filter1).filter(([bookId, title])=>!prethodnoOdabraniNaslovi.includes(`${storeId} ${bookId}`))
      
      const filter3 = this.applyFilter3(filter2, filterValue);
      console.log(`filter1_2_3 za storeId: ${storeId}`);
      console.log(filter3);
      return filter3;
    }
    
    const filter3 = this.applyFilter3(Object.entries(filter1),filterValue);
    console.log(`filter1_2 za storeId: ${storeId}`);
    console.log(filter3);
    return filter3;
  }

  applyFilter3(filter:[string,string][], filterValue:string){
    return filter
      .filter(([bookId, bookName])=>bookName.toLowerCase().includes(filterValue))
      .map(([bookId,bookName])=> [Number(bookId),bookName] as [number,string]);
  }

  addStoreAutocompleteInput(){
    this.storesAutocompleteInputs.push(new FormControl('', Validators.required));
    this.setFilteredStoreOptions();
  }
  
  addBookAutocompleteInput(){
    this.booksAutocompleteInputs.push(new FormControl('',  Validators.required));
    this.setFilteredBookOptions();
  }

  deleteInventoryRow(index: number){
    this.inventoryArray.removeAt(index);
    this.booksAutocompleteInputs.removeAt(index);
    this.storesAutocompleteInputs.removeAt(index);
    this.setFilteredBookOptions();
  }

  onStoreSelected(event:MatAutocompleteSelectedEvent, index:number){
    this.clearBookInSameRow(index);
    const storeId = this.stores.filter(x=>x.storeName == event.option.value).at(0)?.id;
    if(storeId)
      this.inventoryArray.at(index).get('storeId')?.setValue(storeId);
  }

  onBookSelected(event:MatAutocompleteSelectedEvent, index:number){
    const bookId = this.books.filter(x=>x.title == event.option.value).at(0)?.id;
    if(bookId)
      this.inventoryArray.at(index).get('bookId')?.setValue(bookId);
  }

  loadStoreBookPairs() {
    this.inventoryApi.getStoreBookPairs().subscribe({
      next:(response) => this.storeBookPairs = response,
      error:(err) => this.toaster.error("Greška prilikom dohvatanja parova prodavnica i knjiga.")
    });
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

  addNewInventoryRow() {
    const inventoryGroup = new FormGroup ({
          storeId: new FormControl('', Validators.required),
          bookId: new FormControl('', Validators.required),
          quantityInStock: new FormControl('', Validators.required),
          reorderTreshold: new FormControl('', Validators.required),
          location: new FormControl('', this.validateLocation())
        });
      this.inventoryArray.push(inventoryGroup);
      this.addStoreAutocompleteInput(); //dodaji novi mat-autocomplete za prodavnice
      this.addBookAutocompleteInput(); //dodaji novi mat-autocomplete za knjige
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