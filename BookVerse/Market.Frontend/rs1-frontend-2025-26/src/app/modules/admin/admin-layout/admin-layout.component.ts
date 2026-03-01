import { Component, inject, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-admin-layout',
  standalone: false,
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.scss'
})
export class AdminLayoutComponent implements OnInit{
  navSections = [
  {
    id:'catalog',
    label:'ADMIN_PANEL.MENU.CATALOG',
    items:[
      {route: '/admin/product-categories',icon:'category', label:'ADMIN_PANEL.MENU.CATEGORIES'},
      {route: '/admin/products',icon:'inventory_2', label:'ADMIN_PANEL.MENU.BOOKS'},
      {route: '/admin/coupons',icon:'local_activity', label:'ADMIN_PANEL.MENU.COUPONS'},
    ]
  },
  {
    id:'orders',
    label:'ADMIN_PANEL.MENU.SECTION',
    items:[
      {route: '/admin/orders',icon:'shopping_cart', label:'ADMIN_PANEL.MENU.ORDERS'},
    ]
  },
    {
    id:'system',
    label:'ADMIN_PANEL.MENU.SYSTEM',
    items:[
      {route: '/admin/settings',icon:'settings', label:'ADMIN_PANEL.MENU.SETTINGS'},
    ]
  },
];

  ngOnInit(): void {
    const saved = localStorage.getItem('navSectionsOrder');
    if(saved){
      const order = JSON.parse(saved);
      this.navSections.sort((a,b)=>order.indexOf(a.id)-order.indexOf(b.id));
      //npr. ako je u localStorage bilo sačuvano
      //['orders', 'catalog', 'system']
      //a redoslijed u ovom fajlu je
      //['catalog', 'orders', 'system']
      
      //1. poziv
      //order.indexOf('catalog') = 1 - order.indexOf('orders') = 0 => rezultat=1, orders ide prije catalog

      //2. poziv
      //order.indexOf('catalog') = 1 - order.indexOf('system') = 2 => rezultat=-1, catalog ide prije system

      //3. poziv
      //order.indexOf('orders') = 0 - order.indexOf('system') = 2 => rezultat=-2, orders ide prije system

      //Zaključak: orders catalog system

    }
  }

  private translate = inject(TranslateService);
  auth = inject(AuthFacadeService);

  currentLang: string;

  languages = [
    { code: 'bs', name: 'Bosanski', flag: '🇧🇦' },
    { code: 'en', name: 'English', flag: '🇬🇧' }
  ];

  constructor() {
    this.currentLang = this.translate.currentLang || 'bs';
  }


  switchLanguage(langCode: string): void {
    this.currentLang = langCode;
    this.translate.use(langCode);
    localStorage.setItem('language', langCode);
  }

  getCurrentLanguage() {
    return this.languages.find(lang => lang.code === this.currentLang);
  }

  onSectionDrop(event: CdkDragDrop<any[]>){
    moveItemInArray(this.navSections, event.previousIndex,event.currentIndex);
    localStorage.setItem('navSectionsOrder',JSON.stringify(this.navSections.map(s=>s.id)))
  }
}
