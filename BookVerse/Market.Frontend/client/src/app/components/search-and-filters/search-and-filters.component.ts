import { Component, ElementRef, inject, OnInit, Renderer2, signal, ViewChild } from '@angular/core';
import { Categories } from '../../shared/models/book/Categories';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-search-and-filters',
  imports: [],
  templateUrl: './search-and-filters.html',
  styleUrl: './search-and-filters.component.css',
})
export class SearchAndFiltersComponent implements OnInit {
  categoryService = inject(CategoriesService);
  categories = signal<Array<Categories>>([]);

  @ViewChild('searchAndFilters') searchAndFilters!: ElementRef;
  @ViewChild('filterButtonText') filterButtonText!: ElementRef<HTMLHeadingElement>;

  filtersOpened = false;

  ngOnInit(): void {
    this.categoryService.getCategoriesFromApi().subscribe((category: any) => {
      this.categories.set(category.items);
    });
  }

  showFilters() {
    if (!this.filtersOpened) {
      this.searchAndFilters.nativeElement.classList.add('show-filters');
      this.filterButtonText.nativeElement.textContent = 'Zatvori';
    } else {
      this.searchAndFilters.nativeElement.classList.remove('show-filters');
      this.filterButtonText.nativeElement.textContent = 'Filteri';
    }
    this.filtersOpened = !this.filtersOpened;
  }
}
