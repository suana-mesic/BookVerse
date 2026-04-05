import { NgModule } from '@angular/core';

import { PublicRoutingModule } from './public-routing-module';
import { PublicLayoutComponent } from './public-layout/public-layout.component';
import { SearchProductsComponent } from './search-products/search-products.component';
import { SharedModule } from '../shared/shared-module';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [PublicLayoutComponent, SearchProductsComponent],
  imports: [SharedModule, PublicRoutingModule, TranslateModule],
  exports: [TranslateModule],
})
export class PublicModule {}
