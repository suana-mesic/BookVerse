import {
  Component,
  ElementRef,
  HostListener,
  inject,
  OnInit,
  viewChild,
  ViewChild,
} from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CurrentUserService } from '../../core/services/auth/current-user.service';
import { AuthFacadeService } from '../../core/services/auth/auth-facade.service';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  imports: [RouterLink, TranslateModule],
  templateUrl: './header.component.html',
  styleUrl: 'header.component.css',
})
export class HeaderComponent implements OnInit {
  @ViewChild('dropMenu') dropMenu!: ElementRef;
  @ViewChild('userName') userName!: ElementRef;

  router = inject(Router);
  dropMenuOpened = false;
  authFacadeService = inject(AuthFacadeService);
  private translate = inject(TranslateService);

  currentLang: 'bs' | 'en' = 'bs';
  langMenuOpen = false;

  ngOnInit(): void {
    const saved = localStorage.getItem('lang') as 'bs' | 'en' | null;
    if (saved === 'bs' || saved === 'en') {
      this.currentLang = saved;
      this.translate.use(saved);
    }
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

  // ngOnInit(): void {
  //   if(this.userService.isAuthenticated()){
  //     this.userName.nativeElement.innerText=this.userService.currentUser()?.email??'';
  //   }
  // }

  prijavaIliDropDown() {
    console.log(this.authFacadeService.isAuthenticated());
    if (!this.authFacadeService.isAuthenticated()) this.router.navigate(['/auth/login']);
    else {
      this.showDropMenu();
    }
  }
}
