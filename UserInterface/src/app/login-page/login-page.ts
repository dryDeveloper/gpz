import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';
import { InputTextModule } from 'primeng/inputtext';
import { AuthService } from '../services/authentication/auth-service';
import { FormsModule, NgForm } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { MessageModule } from 'primeng/message';

@Component({
  selector: 'app-login-page',
  imports: [DividerModule, ButtonModule, InputTextModule, FormsModule, ToastModule, MessageModule],
  providers: [MessageService],
  templateUrl: './login-page.html',
  styleUrl: './login-page.scss',
})
export class LoginPage {

  user: string = "";
  password: string = "";
  private msgService = inject(MessageService);
  private router = inject(Router);
  private authService = inject(AuthService);
  invalidCreds = signal(false);
  loading = signal(false);

  onLogin(f: NgForm): void {
    this.loading.set(true);
    this.authService.Authenticate(f.value.username, f.value.password).subscribe(r => {
      this.loading.set(false);
      if (r.validCreds) {
        localStorage.setItem("token", r.payload);
        this.authService.token.set(r.payload);
        this.router.navigate(['/home']);
        this.invalidCreds.set(false);
      }
      else
        this.invalidCreds.set(true);
    }, (error) => {
        this.msgService.add({
          severity: 'error',
          summary: 'Network Error',
          detail: 'Cannot reach server, please check your internet connection'
        });
      console.log("there was an error");
      console.error(error.message);
    });
  }

}
