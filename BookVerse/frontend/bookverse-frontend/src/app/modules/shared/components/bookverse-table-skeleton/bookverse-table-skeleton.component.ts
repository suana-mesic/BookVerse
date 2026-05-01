import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-bookverse-table-skeleton',
  standalone: false,
  templateUrl: './bookverse-table-skeleton.component.html',
  styleUrl: './bookverse-table-skeleton.component.scss',
})
export class BookverseTableSkeletonComponent {
  @Input() rows: number = 5;
  @Input() columns: number = 3;
  @Input() showActions: boolean = true;

  get rowsArray(): number[] {
    return Array(this.rows).fill(0).map((_, i) => i);
  }

  get columnsArray(): number[] {
    return Array(this.columns).fill(0).map((_, i) => i);
  }
}
