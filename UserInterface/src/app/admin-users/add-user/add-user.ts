import { Component, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from '../../services/user/user-service';
import { MessageService } from 'primeng/api';

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

  profiles: any[] = [];
  selected_profile: any;
  private userService = inject(UserService);
  loading = signal(false);

  new_user: User = {
    Username: "",
    Password: "",
    Firstname: "",
    Lastname: "",
    Profile: 0
  };

  ngOnInit(): void {
  // TODO: fetch profiles from backend
    this.profiles = [
      { id: 1, description: 'SysAdmin' },
      { id: 2, description: 'Admin' },
      { id: 3, description: 'Call Agent' }
    ]
  }

  onCreateUser(): void {
    // console.log(this.selected_profile);
    this.new_user.Profile = this.selected_profile.id;
    // console.log(this.new_user);
    this.loading.set(true)
    this.userService.CreateUser(this.new_user)
      .subscribe(r => {
        // TODO: return a flag to validate successfull creation of user in backend
        // display user creation success message to user
        console.log(r);
        this.loading.set(false);
      },
      (error)=> {
        console.log(error);
      });
  }

}

