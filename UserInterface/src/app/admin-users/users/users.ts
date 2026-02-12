import { Component, inject, OnInit, signal } from '@angular/core';
import { UserService } from '../../services/user/user-service';
import { TableModule } from 'primeng/table';
import { SkeletonModule } from 'primeng/skeleton';

@Component({
  selector: 'app-users',
  imports: [TableModule, SkeletonModule],
  templateUrl: './users.html',
  styleUrl: './users.scss',
})
export class Users implements OnInit {

  users = signal<User[]>([]);
  userService = inject(UserService);

  private onUsersLoad() {
    this.userService.GetUsers().subscribe(u => this.users.set(u));
  }

  ngOnInit() {
    this.onUsersLoad();
  }

}
