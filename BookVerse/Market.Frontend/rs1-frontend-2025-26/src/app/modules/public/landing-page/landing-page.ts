import { Component, ViewEncapsulation } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { SearchAndFiltersComponent } from '../search-and-filters/search-and-filters.component';
import { BodyComponent } from '../body/body.component';

@Component({
  selector: 'app-landing-page',
  imports: [HeaderComponent, BodyComponent, SearchAndFiltersComponent],
  templateUrl: './landing-page.html',
  styleUrl: './landing-page.scss',
  encapsulation: ViewEncapsulation.None, // Ovo će učiniti da stilovi budu globalni
})
export class LandingPage {}
