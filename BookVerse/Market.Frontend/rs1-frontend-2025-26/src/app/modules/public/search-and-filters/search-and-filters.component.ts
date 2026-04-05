import { Component, ElementRef, inject, OnInit, Renderer2, signal, ViewChild } from '@angular/core';
import { CategoriesService } from '../Petar/categories.service';
import { Categories } from '../Petar/book/Categories';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-search-and-filters',
  standalone: true,
  imports: [TranslateModule],
  templateUrl: './search-and-filters.html',
  styleUrl: './search-and-filters.component.css',
})
export class SearchAndFiltersComponent implements OnInit {
  categoryService = inject(CategoriesService);
  private translate = inject(TranslateService);
  categories = signal<Array<Categories>>([]);

  @ViewChild('searchAndFilters') searchAndFilters!: ElementRef;
  @ViewChild('authorDropMenu') authorDropMenu!: ElementRef;
  @ViewChild('categoryDropMenu') categoryDropMenu!: ElementRef;
  @ViewChild('filterButtonText') filterButtonText!: ElementRef<HTMLHeadingElement>;

  filtersOpened = false;
  authorsOpened = false;

  ngOnInit(): void {
    this.categoryService.getCategoriesFromApi().subscribe((category: any) => {
      this.categories.set(category.items);
    });
  }

  showFilters() {
    if (!this.filtersOpened) {
      this.searchAndFilters.nativeElement.classList.add('show-filters');
      this.filterButtonText.nativeElement.textContent = this.translate.instant(
        'CLIENT.SEARCH.CLOSE_FILTERS',
      );
    } else {
      this.searchAndFilters.nativeElement.classList.remove('show-filters');
      this.filterButtonText.nativeElement.textContent =
        this.translate.instant('CLIENT.SEARCH.FILTERS');
    }
    this.filtersOpened = !this.filtersOpened;
  }

  showAuthors() {
    if (!this.authorsOpened) {
      this.searchAndFilters.nativeElement.style.overflow = 'visible';
      this.authorDropMenu.nativeElement.style.display = 'block';
    }
    if (this.authorsOpened) {
      this.searchAndFilters.nativeElement.style.overflow = 'hidden';
      this.authorDropMenu.nativeElement.style.display = 'none';
    }
    this.authorsOpened = !this.authorsOpened;
  }

  showCategories() {
    if (!this.authorsOpened) {
      this.searchAndFilters.nativeElement.style.overflow = 'visible';
      this.categoryDropMenu.nativeElement.style.display = 'block';
    }
    if (this.authorsOpened) {
      this.searchAndFilters.nativeElement.style.overflow = 'hidden';
      this.categoryDropMenu.nativeElement.style.display = 'none';
    }
    this.authorsOpened = !this.authorsOpened;
  }
}
