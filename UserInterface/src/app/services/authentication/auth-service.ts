import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private http = inject(HttpClient);

  public token = signal("");

  public Authenticate(usr: string, pwd: string) {
    return this.http.post<AuthResponse>(
      "http://localhost:5039/users/login",
      { "userName": usr, "password": pwd }
    );
  }

}
