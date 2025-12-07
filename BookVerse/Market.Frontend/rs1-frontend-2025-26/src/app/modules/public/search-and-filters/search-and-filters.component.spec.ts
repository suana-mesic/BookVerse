import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchAndFiltersComponent } from './search-and-filters.component';

describe('SearchAndFiltersComponent', () => {
  let component: SearchAndFiltersComponent;
  let fixture: ComponentFixture<SearchAndFiltersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SearchAndFiltersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchAndFiltersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
