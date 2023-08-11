import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }
  private urlApi = 'http://meitensaku-001-site1.gtempurl.com/api/Product';


  getProduct(id:number):Observable<any>{
    return this.http.get(`${this.urlApi}/${id}`);
  }
}
