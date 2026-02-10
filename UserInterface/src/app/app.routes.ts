import { Routes } from '@angular/router';
import { LoginPage } from './login-page/login-page';
import { HomePage } from './home-page/home-page';
import { PrintCreditRequests } from './print-credit-requests/print-credit-requests';
import { ImportCreditRequests } from './import-credit-requests/import-credit-requests';
import { CreditRequestStats } from './credit-request-stats/credit-request-stats';
import { AddUser } from './admin-users/add-user/add-user';
import { Users } from './admin-users/users/users';
import { authGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'login', component: LoginPage, title: 'Login Page' },
  {
    path: 'home', component: HomePage, title: 'Home Page', canActivate: [authGuard], children: [
      { path: 'stats', component: CreditRequestStats, title: 'Credit Request Stats' },
      { path: 'print', component: PrintCreditRequests, title: 'Print Credit Request' },
      { path: 'import', component: ImportCreditRequests, title: 'Import Credit Requests' },
      { path: 'add-user', component: AddUser, title: 'Add User' },
      { path: 'users', component: Users, title: 'Users' }
    ]
  },
];
