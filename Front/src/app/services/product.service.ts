// product.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../interfaces/category.interface';

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  constructor(private http: HttpClient) { }
  private urlApi = 'http://meitensaku-001-site1.gtempurl.com/api/Product';


  getProduct(id:number):Observable<any>{
    return this.http.get(`${this.urlApi}/${id}`);
  }
  searchProducts(searchTerm: string, currentPage: number, arg2: number) {
    throw new Error('Method not implemented.');
  }

  getCategories(): Observable<Category[]> {
    // Hacer la solicitud a la API para obtener las categorías y productos
    const apiUrl = 'http://meitensaku-001-site1.gtempurl.com/api/Category/products';
    return this.http.get<Category[]>(apiUrl);
  }
}
