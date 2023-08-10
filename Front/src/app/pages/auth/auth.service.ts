import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://meitensaku-001-site1.gtempurl.com/api/Account';

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const body = { username, password };
    return this.http.post(`${this.apiUrl}/login`, body);
  }

  // Verifica la existencia del usuario en la API
  checkUserExistence(username: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/users/${username}`);
  }

}
