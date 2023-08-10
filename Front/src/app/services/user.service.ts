import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  onLogin(obj: any): Observable<any> {
    return this.http.post('http://meitensaku-001-site1.gtempurl.com/api/Account/Login', obj)
      .pipe(
        catchError(this.handleError)
      );
  }

  onRegister(obj: any): Observable<any> {
    return this.http.post('http://meitensaku-001-site1.gtempurl.com/api/Account/register', obj)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Hubo un error en la solicitud. Por favor, intenta nuevamente más tarde.';

    if (error.error && error.error.message) {
      errorMessage = error.error.message;
    }

    console.error('Error en la solicitud:', error);
    console.error('Mensaje de error:', errorMessage);

    // Retorna un observable con el mensaje de error personalizado
    return throwError(errorMessage);
  }
}
