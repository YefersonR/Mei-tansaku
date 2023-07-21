import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { products } from '../interfaces/product.interface';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl = 'http://meitensaku-001-site1.gtempurl.com/api/category/'

  constructor(private httpClient: HttpClient) { }

  getProducts(): Observable<products[]> {
    const response = this.httpClient.get<products[]>(`${this.baseUrl}products/19`)
    console.log(response)
    return response;
  }
}
