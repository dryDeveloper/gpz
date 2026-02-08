import { Component, inject, OnInit, signal } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { AvatarModule } from 'primeng/avatar';
import { ButtonModule } from 'primeng/button';
import { Router, RouterOutlet } from '@angular/router';
import { TableModule } from 'primeng/table';
import { AuthService } from '../services/auth-service';

@Component({
  selector: 'app-home-page',
  imports: [MenubarModule, AvatarModule, ButtonModule, TableModule, RouterOutlet],
  templateUrl: './home-page.html',
  styleUrl: './home-page.scss',
})
export class HomePage implements OnInit {

  private authService = inject(AuthService);
  items: MenuItem[] | undefined;
  users = signal<User[]>([]);

  constructor(private router: Router) {
  }

  logOut(): void {
    localStorage.clear();
    this.authService.token.set("");
    this.router.navigate(['/login']);
  }

  // private onUsersLoad() {
  //   this.userService.GetUsers().subscribe(u => this.users.set(u));
  // }

  ngOnInit(): void {
    this.items = [
      { label: 'Home', icon: 'pi pi-home', routerLink: ['/home/stats'] },
      {
        label: 'Credit Requests', icon: 'pi pi-book', items: [
          { label: 'Print', icon: 'pi pi-print', routerLink: ['/home/print'] },
          { label: 'Import', icon: 'pi pi-file-import', routerLink: ['/home/import'] },
          { label: 'Search', icon: 'pi pi-search' },
        ]
      },
      { label: 'Contact', icon: 'pi pi-envelope' }
    ];
    this.router.navigate(['/home/stats']);
  }

}
