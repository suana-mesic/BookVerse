import { Injectable, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({ providedIn: 'root' })
export class SoundService {
  private audio = new Audio('assets/audio/pixel_notification.mp3');
  private translate = inject(TranslateService);

  play() {
    this.audio.currentTime = 0;
    this.audio.play().catch(() => {
      console.warn(this.translate.instant('COMMON.AUTOPLAY_BLOCKED'));
    });
  }
}
