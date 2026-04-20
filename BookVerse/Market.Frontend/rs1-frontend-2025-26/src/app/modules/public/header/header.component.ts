import {
  Component,
  ElementRef,
  HostListener,
  inject,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthFacadeService } from '../../core/services/auth/auth-facade.service';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { SignalRService } from '../../../core/services/signal-r/signal-r.service';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  imports: [RouterLink, TranslateModule, MatIconModule, MatBadgeModule, MatMenuModule, MatButtonModule, MatDividerModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: 'header.component.css',
})
export class HeaderComponent implements OnInit, OnDestroy {
  @ViewChild('dropMenu') dropMenu!: ElementRef;
  @ViewChild('userName') userName!: ElementRef;

  router = inject(Router);
  dropMenuOpened = false;
  authFacadeService = inject(AuthFacadeService);
  signalR = inject(SignalRService);
  private translate = inject(TranslateService);
  private langChangeSub!: Subscription;

  currentLang: 'bs' | 'en' = 'bs';
  langMenuOpen = false;

  ngOnInit(): void {
    const saved = localStorage.getItem('lang') as 'bs' | 'en' | null;
    if (saved === 'bs' || saved === 'en') {
      this.currentLang = saved;
      this.translate.use(saved);
    }

    this.langChangeSub = this.translate.onLangChange.subscribe((event) => {
      this.currentLang = event.lang as 'bs' | 'en';
    });
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
  }

  markAllAsRead(): void {
    this.signalR.markUserNotificationsRead();
  }

  clearNotifications(): void {
    this.signalR.clearUserNotifications();
  }

  toggleLangMenu(event: Event): void {
    event.stopPropagation();
    this.langMenuOpen = !this.langMenuOpen;
  }

  selectLang(lang: 'bs' | 'en', event: Event): void {
    event.stopPropagation();
    this.currentLang = lang;
    this.langMenuOpen = false;
    this.translate.use(lang);
    localStorage.setItem('lang', lang);
    const savedSettings = localStorage.getItem('userSettings');
    const settings = savedSettings ? JSON.parse(savedSettings) : {};
    settings.language = lang;
    localStorage.setItem('userSettings', JSON.stringify(settings));
  }

  @HostListener('document:click')
  closeLangMenu(): void {
    this.langMenuOpen = false;
  }

  showDropMenu() {
    console.log(this.dropMenu);
    if (!this.dropMenuOpened) {
      this.dropMenu.nativeElement.style.height = '455px';
    } else {
      this.dropMenu.nativeElement.style.height = '0px';
    }
    this.dropMenuOpened = !this.dropMenuOpened;
  }

  prijavaIliDropDown() {
    console.log(this.authFacadeService.isAuthenticated());
    if (!this.authFacadeService.isAuthenticated()) this.router.navigate(['/auth/login']);
    else {
      this.showDropMenu();
    }
  }
}
