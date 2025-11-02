import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookDetailsCrud } from './book-details-crud';

describe('BookDetailsCrud', () => {
  let component: BookDetailsCrud;
  let fixture: ComponentFixture<BookDetailsCrud>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookDetailsCrud]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookDetailsCrud);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
