import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookListCrud } from './book-list-crud';

describe('BookListCrud', () => {
  let component: BookListCrud;
  let fixture: ComponentFixture<BookListCrud>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookListCrud]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookListCrud);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
