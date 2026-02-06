import { Routes } from '@angular/router';
import { LoginPage } from './login-page/login-page';
import { HomePage } from './home-page/home-page';

export const routes: Routes = [
  { path: 'login', component: LoginPage, title: 'Login Page' },
  { path: 'home', component: HomePage, title: 'Home Page' }
];
