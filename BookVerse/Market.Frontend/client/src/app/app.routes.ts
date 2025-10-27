import { Routes } from '@angular/router';
import { Login } from './features/login/login';
import { WizardRegister } from './features/wizard-register/wizard-register';

export const routes: Routes = [
    { path: 'login', component: Login },
    { path: 'register', component: WizardRegister },
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: '**', redirectTo: '/login' } //bilo koja putanja koja nije definisana preusmjerava se na login
];