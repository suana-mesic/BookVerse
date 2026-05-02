import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { BookversePaginatorBarComponent } from './components/bookverse-paginator-bar/bookverse-paginator-bar.component';
import { materialModules } from './material-modules';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { BookverseConfirmDialogComponent } from './components/bookverse-confirm-dialog/bookverse-confirm-dialog.component';
import { DialogHelperService } from './services/dialog-helper.service';
import { BookverseLoadingBarComponent } from './components/bookverse-loading-bar/bookverse-loading-bar.component';
import { BookverseTableSkeletonComponent } from './components/bookverse-table-skeleton/bookverse-table-skeleton.component';
import { MatIconModule } from '@angular/material/icon';
import { ImageUploadComponent } from './components/image-upload/image-upload.component';
import { RouterModule } from '@angular/router';
import { AppDatePipe } from './pipes/date-pipe';
import { AppNumberPipe } from './pipes/number-pipe';
import { ApiUrlPipe } from './pipes/api-url.pipe';
import { OpeningHoursPipe } from './pipes/opening-hours.pipe';
import { DynamicDateAdapter } from './adapters/dynamic-date.adapter';
import { DateFormatService } from './services/date-format.service';
import { DateAdapter } from '@angular/material/core';
import { TranslateService } from '@ngx-translate/core';

@NgModule({
  declarations: [
    BookversePaginatorBarComponent,
    BookverseConfirmDialogComponent,
    BookverseLoadingBarComponent,
    BookverseTableSkeletonComponent,
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
    ApiUrlPipe,
    AppNumberPipe,
    OpeningHoursPipe,
    ...materialModules,
  ],
  providers: [
    DialogHelperService,
    DatePipe,
    { provide: DateAdapter, useClass: DynamicDateAdapter, deps: [DateFormatService, TranslateService] },
  ],
  exports: [
    BookversePaginatorBarComponent,
    CommonModule,
    ReactiveFormsModule,
    TranslatePipe,
    FormsModule,
    BookverseLoadingBarComponent,
    BookverseTableSkeletonComponent,
    ImageUploadComponent,
    RouterModule,
    AppDatePipe,
    AppNumberPipe,
    ApiUrlPipe,
    OpeningHoursPipe,
    materialModules,
  ],
})
export class SharedModule {}
