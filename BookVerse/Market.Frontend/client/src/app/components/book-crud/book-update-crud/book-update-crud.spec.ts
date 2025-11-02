import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookUpdateCrud } from './book-update-crud';

describe('BookUpdateCrud', () => {
  let component: BookUpdateCrud;
  let fixture: ComponentFixture<BookUpdateCrud>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookUpdateCrud]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookUpdateCrud);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
