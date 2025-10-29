import { Routes } from '@angular/router';
import { Login } from './features/login/login';
import { WizardRegister } from './features/wizard-register/wizard-register';
import { LandingPage } from './components/landing-page/landing-page';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: WizardRegister },
  // { path: '', redirectTo: '/login', pathMatch: 'full' },
  // { path: '**', redirectTo: '/login' } //bilo koja putanja koja nije definisana preusmjerava se na login

  // Petar: Zakomentirao sam gornje dvije linije jer ce default komponenta biti landing page
  { path: '', component: LandingPage },
  { path: '**', redirectTo: '/' }, //bilo koja putanja koja nije definisana preusmjerava se na login
];
