import { Component, inject, OnInit, signal } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CascadeSelectModule } from 'primeng/cascadeselect';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { UserService } from '../../services/user-service';

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
  selected_profile: number = 0;
  private userService = inject(UserService);
  loading = signal(false);

  new_user: User = {
    Username: "",
    Firstname: "",
    Lastname: "",
    ProfileId: 0,
    ProfileName: ""
  };

  ngOnInit(): void {
    this.profiles = [
      { profile_id: 1, name: 'SysAdmin' },
      { profile_id: 2, name: 'Admin' },
      { profile_id: 3, name: 'Call Agent' }
    ]
  }

  onCreateUser() {
    console.log(this.new_user);
    this.loading.set(true)
    this.userService.CreateUser(this.new_user).subscribe(r => {
      // TODO: return a flag to validate successfull creation of user in backend
      // display user creation success message to user
      this.loading.set(false);
    });
  }

}
