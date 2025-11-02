import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookCrud } from './book-crud';

describe('BookCrud', () => {
  let component: BookCrud;
  let fixture: ComponentFixture<BookCrud>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookCrud]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookCrud);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
