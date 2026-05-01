import { Component, inject } from '@angular/core';
import {LoadingBarService} from '../../../../core/services/loading-bar.service';

@Component({
  selector: 'app-bookverse-loading-bar',
  standalone: false,
  templateUrl: './bookverse-loading-bar.component.html',
  styleUrl: './bookverse-loading-bar.component.scss',
})
export class BookverseLoadingBarComponent {
  /**
   * Inject LoadingBarService to access loading state
   * Component subscribes to loading$ observable to show/hide bar
   */
  protected loadingBar = inject(LoadingBarService);
}
