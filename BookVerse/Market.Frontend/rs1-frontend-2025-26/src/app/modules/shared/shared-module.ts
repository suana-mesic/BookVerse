import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FitPaginatorBarComponent } from './components/fit-paginator-bar/fit-paginator-bar.component';
import { materialModules } from './material-modules';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { FitConfirmDialogComponent } from './components/fit-confirm-dialog/fit-confirm-dialog.component';
import { DialogHelperService } from './services/dialog-helper.service';
import { FitLoadingBarComponent } from './components/fit-loading-bar/fit-loading-bar.component';
import { FitTableSkeletonComponent } from './components/fit-table-skeleton/fit-table-skeleton.component';
import { MatIconModule } from '@angular/material/icon';
import { ImageUploadComponent } from './components/image-upload/image-upload.component';
import { RouterModule } from '@angular/router';
import { AppDatePipe } from './pipes/date-pipe';
import { DynamicDateAdapter } from './adapters/dynamic-date.adapter';
import { DateFormatService } from './services/date-format.service';
import { DateAdapter } from '@angular/material/core';

@NgModule({
  declarations: [
    FitPaginatorBarComponent,
    FitConfirmDialogComponent,
    FitLoadingBarComponent,
    FitTableSkeletonComponent,
    ImageUploadComponent,
    AppDatePipe,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    ReactiveFormsModule,
    FormsModule,
    TranslatePipe,
    RouterModule,
    ...materialModules,
  ],
  providers: [
    DialogHelperService,
    DatePipe,
    { provide: DateAdapter, useClass: DynamicDateAdapter, deps: [DateFormatService] },
  ],
  exports: [
    FitPaginatorBarComponent,
    CommonModule,
    ReactiveFormsModule,
    TranslatePipe,
    FormsModule,
    FitLoadingBarComponent,
    FitTableSkeletonComponent,
    ImageUploadComponent,
    RouterModule,
    AppDatePipe,
    materialModules,
  ],
})
export class SharedModule {}
