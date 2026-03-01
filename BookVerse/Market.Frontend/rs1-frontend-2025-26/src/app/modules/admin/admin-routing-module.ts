import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { BooksComponent } from './catalogs/book/books.component';
import { BooksAddComponent } from './catalogs/book/books-add/books-add.component';
import { BooksEditComponent } from './catalogs/book/books-edit/books-edit.component';
import { ProductCategoriesComponent } from './catalogs/product-categories/product-categories.component';
import { AdminOrdersComponent } from './orders/admin-orders.component';
import { AdminSettingsComponent } from './admin-settings/admin-settings.component';
import { CouponsDynamicFormAddComponent } from './coupons-dynamic-form/coupons-dynamic-form-add.component';

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


      {
        path: 'settings',
        component: AdminSettingsComponent,
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
