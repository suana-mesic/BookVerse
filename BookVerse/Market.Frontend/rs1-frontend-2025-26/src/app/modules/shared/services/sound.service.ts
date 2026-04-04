import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class SoundService {
  private audio = new Audio('assets/audio/pixel_notification.mp3');

  play() {
    this.audio.currentTime = 0;
    this.audio.play().catch(() => {
      console.warn('Browser blokirao autoplay zvuka');
    });
  }
}
