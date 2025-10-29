import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';
import { SearchAndFiltersComponent } from './components/search-and-filters/search-and-filters.component';
import { BodyComponent } from './components/body/body.component';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, SearchAndFiltersComponent, BodyComponent],
  template: `
    <app-header />
    <app-search-and-filters />
    <app-body />
  `,
  styles: [],
})
export class AppComponent {
  title = 'bookverse';
}
