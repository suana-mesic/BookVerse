import { NgModule } from '@angular/core';

import { AdminRoutingModule } from './admin-routing-module';
import { BooksComponent } from './catalogs/book/books.component';
import { BooksAddComponent } from './catalogs/book/books-add/books-add.component';
import { BooksEditComponent } from './catalogs/book/books-edit/books-edit.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { ProductCategoriesComponent } from './catalogs/product-categories/product-categories.component';
import { ProductCategoryUpsertComponent } from './catalogs/product-categories/product-category-upsert/product-category-upsert.component';
import { AdminOrdersComponent } from './orders/admin-orders.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { SharedModule } from '../shared/shared-module';
import { OrderDetailsDialogComponent } from './orders/admin-orders-details-dialog/order-details-dialog.component';
import { ChangeStatusDialogComponent } from './orders/change-status-dialog/change-status-dialog.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CouponsDynamicFormAddComponent } from './coupons-dynamic-form/coupons-dynamic-form-add.component';
import { InventoryComponent } from './inventory/inventory.component';
import { InventoryEditComponent } from './inventory/inventory-edit/inventory-edit.component';
import { InventoryAddComponent } from './inventory/inventory-add/inventory-add.component';
import { MatTabsModule } from '@angular/material/tabs';
import { UsersComponent } from './users/users.component';
import { UsersEditComponent } from './users/users-edit/users-edit.component';
import { AdminSettingsComponent } from './admin-settings/admin-settings.component';
@NgModule({
  declarations: [
    BooksComponent,
    BooksAddComponent,
    BooksEditComponent,
    AdminLayoutComponent,
    ProductCategoriesComponent,
    ProductCategoryUpsertComponent,
    AdminOrdersComponent,
    StatisticsComponent,
    OrderDetailsDialogComponent,
    ChangeStatusDialogComponent,
    CouponsDynamicFormAddComponent,
    InventoryComponent,
    InventoryEditComponent,
    InventoryAddComponent,
    UsersComponent,
    UsersEditComponent,
    AdminSettingsComponent,
  ],
  imports: [AdminRoutingModule, SharedModule, DragDropModule, MatTabsModule],
})
export class AdminModule {}
