import { Component, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from '../../services/user/user-service';
import { MessageService } from 'primeng/api';
import { ProfileService } from '../../services/profile/profile-service.ts';

@Component({
  selector: 'add-user',
  imports: [
    FloatLabelModule,
    InputTextModule,
    FormsModule,
    ButtonModule,
    CascadeSelectModule
  ],
  templateUrl: './add-user.html',
  styleUrl: './add-user.scss',
})
export class AddUser implements OnInit {

  public profiles: any[] = [];
  public selected_profile: any;
  public loading = signal(false);
  private userService = inject(UserService);
  private profileService = inject(ProfileService);
  private msgService = inject(MessageService);
  public new_user: User = { Username: "", Password: "", Firstname: "", Lastname: "",
    Profile: 0
  };

  public ngOnInit(): void {
    this.profileService.GetProfiles().subscribe(p => this.profiles = p);
  }

  public onCreateUser(): void {
    this.new_user.Profile = this.selected_profile.id;
    this.loading.set(true)
    this.userService.CreateUser(this.new_user).subscribe({
      next: r => {
        console.log(r);
      },
      error: e => {
        this.msgService.add({
          severity: 'warn',
          summary: 'Network Error',
          detail: e
        });
      },
      complete: () => {
        this.loading.set(false);
        this.msgService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'User Created'
        });
      }
    });
  }

}

