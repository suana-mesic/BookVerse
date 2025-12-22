import { NgModule } from '@angular/core';

import { PublicRoutingModule } from './public-routing-module';
import { PublicLayoutComponent } from './public-layout/public-layout.component';
import { SearchProductsComponent } from './search-products/search-products.component';
import { SharedModule } from '../shared/shared-module';
import { MapComponent } from './map/map.component';

@NgModule({
  declarations: [PublicLayoutComponent, SearchProductsComponent, MapComponent],
  imports: [SharedModule, PublicRoutingModule],
})
export class PublicModule {}
