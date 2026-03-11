import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {

  private http = inject(HttpClient);

  public GetProfiles(): Observable<Profile[]> {
    return this.http.get<Profile[]>("https://localhost:7084/profiles");
  }

}
