import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private http = inject(HttpClient);

  public GetUsers() {
    return this.http.get<User[]>("http://localhost:5039/users");
  }
}
