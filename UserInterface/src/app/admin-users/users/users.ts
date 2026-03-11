import { Component, inject, OnInit, signal } from '@angular/core';
import { UserService } from '../../services/user/user-service';
import { TableModule } from 'primeng/table';
import { SkeletonModule } from 'primeng/skeleton';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-users',
  imports: [TableModule, SkeletonModule, ToastModule],
  templateUrl: './users.html',
  styleUrl: './users.scss',
})
export class Users implements OnInit {

  users = signal<User[]>([]);
  userService = inject(UserService);
  msgService = inject(MessageService);

  private onUsersLoad() {
    this.userService.GetUsers().subscribe(u => this.users.set(u), (error) => {
        this.msgService.add({
          severity: 'warn',
          summary: 'Network Error',
          detail: error
        });
    });
  }

  ngOnInit() {
    this.onUsersLoad();
  }

}
