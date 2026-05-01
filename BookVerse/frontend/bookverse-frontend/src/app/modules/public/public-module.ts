import { NgModule } from '@angular/core';

import { PublicRoutingModule } from './public-routing-module';
import { PublicLayoutComponent } from './public-layout/public-layout.component';
import { SharedModule } from '../shared/shared-module';
import { TranslateModule } from '@ngx-translate/core';
import { HeaderComponent } from './header/header.component';
import { SearchAndFiltersComponent } from './search-and-filters/search-and-filters.component';
import { BodyComponent } from './body/body.component';

@NgModule({
  declarations: [PublicLayoutComponent],
  imports: [
    SharedModule,
    PublicRoutingModule,
    TranslateModule,
    HeaderComponent,
    SearchAndFiltersComponent,
    BodyComponent,
  ],
  exports: [TranslateModule],
})
export class PublicModule {}
