import { Component, inject, OnInit, signal } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { AvatarModule } from 'primeng/avatar';
import { ButtonModule } from 'primeng/button';
import { Router, RouterOutlet } from '@angular/router';
import { TableModule } from 'primeng/table';
import { AuthService } from '../services/authentication/auth-service';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-home-page',
  imports: [
    MenubarModule,
    AvatarModule,
    ButtonModule,
    TableModule,
    RouterOutlet,
    ToastModule
  ],
  templateUrl: './home-page.html',
  styleUrl: './home-page.scss',
})
export class HomePage implements OnInit {

  private authService = inject(AuthService);
  items: MenuItem[] | undefined;
  users = signal<User[]>([]);
  private router = inject(Router);

  logOut(): void {
    localStorage.clear();
    this.authService.token.set("");
    this.router.navigate(['/login']);
  }

  ngOnInit(): void {
    this.items = [
      { label: 'Home', icon: 'pi pi-home', routerLink: ['/home/stats'] },
      {
        label: 'Credit Requests', icon: 'pi pi-book', items: [
          { label: 'Print', icon: 'pi pi-print', routerLink: ['/home/print'] },
          { label: 'Import', icon: 'pi pi-file-import', routerLink: ['/home/import'] },
          // { label: 'Search', icon: 'pi pi-search' },
        ]
      },
      {
        label: 'Users', icon: 'pi pi-user', items: [
          { label: 'Add', icon: 'pi pi-user-plus', routerLink: ['/home/add-user'] },
          { label: 'List', icon: 'pi pi-user', routerLink: ['/home/users'] }
        ]
      }
    ];
    this.router.navigate(['/home/stats']);
  }

}
