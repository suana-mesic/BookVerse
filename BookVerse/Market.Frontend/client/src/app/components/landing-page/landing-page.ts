import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { SearchAndFiltersComponent } from '../search-and-filters/search-and-filters.component';
import { BodyComponent } from '../body/body.component';

@Component({
  selector: 'app-landing-page',
  imports: [HeaderComponent, SearchAndFiltersComponent, BodyComponent],
  templateUrl: './landing-page.html',
  styleUrl: './landing-page.scss',
})
export class LandingPage {}
