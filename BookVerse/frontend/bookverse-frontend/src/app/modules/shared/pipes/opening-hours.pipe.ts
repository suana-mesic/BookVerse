import { ChangeDetectorRef, OnDestroy, Pipe, PipeTransform, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';

@Pipe({
  name: 'openingHours',
  standalone: true,
  pure: false,
})
export class OpeningHoursPipe implements PipeTransform, OnDestroy {
  private translate = inject(TranslateService);
  private cdr = inject(ChangeDetectorRef);
  private langChangeSub?: Subscription;
  private cached = '';
  private lastInput = '';
  private lastLang = '';

  transform(value: string | null | undefined): string {
    if (!value) return '';

    if (value === this.lastInput && this.translate.currentLang === this.lastLang) {
      return this.cached;
    }

    if (!this.langChangeSub) {
      this.langChangeSub = this.translate.onLangChange.subscribe(() => this.cdr.markForCheck());
    }

    this.lastInput = value;
    this.lastLang = this.translate.currentLang;
    this.cached = value
      .replace('Ponedjeljak-Petak', this.translate.instant('CLIENT.BOOK_DETAILS.OPENING_HOURS_MON_FRI'))
      .replace('Subota', this.translate.instant('CLIENT.BOOK_DETAILS.OPENING_HOURS_SAT'));
    return this.cached;
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
  }
}
