import { Routes } from '@angular/router';
import { Login } from './components/auth/login/login';
import { LandingPage } from './components/landing-page/landing-page';
import { WizardRegister } from './components/auth/wizard-register/wizard-register';
import { BookCrud } from './components/book-crud/book-crud/book-crud';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: WizardRegister },
  // { path: '', redirectTo: '/login', pathMatch: 'full' },
  // { path: '**', redirectTo: '/login' } //bilo koja putanja koja nije definisana preusmjerava se na login

  // Petar: Zakomentirao sam gornje dvije linije jer ce default komponenta biti landing page
  // Suana: Promijenila sam liniju ispod i umjesto LandingPage dodala BookComponent kako bih testirala crud
  { path: '', component: BookCrud },
  { path: 'knjige', component: LandingPage }, // Testiranje isto
  { path: '**', redirectTo: '/' }, //bilo koja putanja koja nije definisana preusmjerava se na login
];
