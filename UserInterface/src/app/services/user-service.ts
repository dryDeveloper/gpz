import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private http = inject(HttpClient);

  public GetUsers(): Observable<User[]> {
    return this.http.get<User[]>("http://localhost:5039/users");
  }

  public CreateUser(new_user: User) {
    return this.http.post("http://localhost:5029/users", new_user);
  }

}
