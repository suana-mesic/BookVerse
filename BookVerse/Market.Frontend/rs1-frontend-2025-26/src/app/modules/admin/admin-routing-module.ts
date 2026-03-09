import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { BooksComponent } from './catalogs/book/books.component';
import { BooksAddComponent } from './catalogs/book/books-add/books-add.component';
import { BooksEditComponent } from './catalogs/book/books-edit/books-edit.component';
import { ProductCategoriesComponent } from './catalogs/product-categories/product-categories.component';
import { AdminOrdersComponent } from './orders/admin-orders.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { CouponsDynamicFormAddComponent } from './coupons-dynamic-form/coupons-dynamic-form-add.component';
import { InventoryComponent } from './inventory/inventory.component';
import { InventoryAddComponent } from './inventory/inventory-add/inventory-add.component';
import { InventoryEditComponent } from './inventory/inventory-edit/inventory-edit.component';

const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      // BOOKS
      {
        path: 'products',
        component: BooksComponent,
      },
      {
        path: 'products/add',
        component: BooksAddComponent,
      },
      {
        path: 'products/:id/edit',
        component: BooksEditComponent,
      },

      // BOOKS CATEGORIES
      {
        path: 'product-categories',
        component: ProductCategoriesComponent,
      },

      {
        path: 'orders',
        component: AdminOrdersComponent,
      },

      {
        path: 'coupons',
        component: CouponsDynamicFormAddComponent,
      },
      //inventory
      {
        path: 'inventory',
        component: InventoryComponent,
      },

      {
        path: 'inventory/add',
        component: InventoryAddComponent,
      },
      {
        path: 'inventory/edit/store/:storeId/book/:bookId',
        component: InventoryEditComponent,
      },

      {
        path: 'statistics',
        component: StatisticsComponent,
      },


      // default admin route → /admin/products
      {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule { }
