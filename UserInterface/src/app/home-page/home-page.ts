import { Component, inject, OnInit, signal } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { AvatarModule } from 'primeng/avatar';
import { ButtonModule } from 'primeng/button';
import { Router } from '@angular/router';
import { UserService } from '../services/user-service';
import { TableModule } from 'primeng/table';
import { AuthService } from '../services/auth-service';

@Component({
  selector: 'app-home-page',
  imports: [MenubarModule, AvatarModule, ButtonModule, TableModule],
  templateUrl: './home-page.html',
  styleUrl: './home-page.scss',
})
export class HomePage implements OnInit {

  private userService = inject(UserService);
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

  private onUsersLoad() {
    this.userService.GetUsers().subscribe(u => this.users.set(u));
  }

  ngOnInit(): void {
    this.onUsersLoad();
    this.items = [
      { label: 'Home', icon: 'pi pi-home' },
      { label: 'Features', icon: 'pi pi-star' },
      {
        label: 'Projects', icon: 'pi pi-search', items: [
          { label: 'Components', icon: 'pi pi-bolt' },
          { label: 'Blocks', icon: 'pi pi-server' },
          { label: 'UI Kit', icon: 'pi pi-pencil' },
          {
            label: 'Templates', icon: 'pi pi-palette', items: [
              { label: 'Apollo', icon: 'pi pi-palette' },
              { label: 'Ultima', icon: 'pi pi-palette' }
            ]
          }
        ]
      },
      { label: 'Contact', icon: 'pi pi-envelope' }
    ];
  }

}
