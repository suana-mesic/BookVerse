import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookCreateCrud } from './book-create-crud';

describe('BookCreateCrud', () => {
  let component: BookCreateCrud;
  let fixture: ComponentFixture<BookCreateCrud>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookCreateCrud]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookCreateCrud);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
