import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  searchProducts(searchTerm: string, currentPage: number, arg2: number) {
    throw new Error('Method not implemented.');
  }

  constructor(private http: HttpClient) { }

}
