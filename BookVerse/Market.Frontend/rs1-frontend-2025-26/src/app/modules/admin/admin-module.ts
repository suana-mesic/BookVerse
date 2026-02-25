import {NgModule} from '@angular/core';

import {AdminRoutingModule} from './admin-routing-module';
import {BooksComponent} from './catalogs/book/books.component';
import {BooksAddComponent} from './catalogs/book/books-add/books-add.component';
import {BooksEditComponent} from './catalogs/book/books-edit/books-edit.component';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {ProductCategoriesComponent} from './catalogs/product-categories/product-categories.component';
import {
  ProductCategoryUpsertComponent
} from './catalogs/product-categories/product-category-upsert/product-category-upsert.component';
import {AdminOrdersComponent} from './orders/admin-orders.component';
import {AdminSettingsComponent} from './admin-settings/admin-settings.component';
import {SharedModule} from '../shared/shared-module';
import { OrderDetailsDialogComponent } from './orders/admin-orders-details-dialog/order-details-dialog.component';
import { ChangeStatusDialogComponent } from './orders/change-status-dialog/change-status-dialog.component';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [
    BooksComponent,
    BooksAddComponent,
    BooksEditComponent,
    AdminLayoutComponent,
    ProductCategoriesComponent,
    ProductCategoryUpsertComponent,
    AdminOrdersComponent,
    AdminSettingsComponent,
    OrderDetailsDialogComponent,
    ChangeStatusDialogComponent
  ],
  imports: [
    AdminRoutingModule,
    SharedModule,
    DragDropModule
  ]
})
export class AdminModule { }
