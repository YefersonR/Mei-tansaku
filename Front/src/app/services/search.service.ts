import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  searchProducts(searchTerm: string): Observable<any[]> { // Asegúrate de que el tipo de retorno sea un arreglo
    const apiUrl = `http://meitensaku-001-site1.gtempurl.com/api/Product?name=${searchTerm}`;
    return this.http.get<any[]>(apiUrl); // Asegúrate de que el tipo de retorno sea un arreglo
  }
}
