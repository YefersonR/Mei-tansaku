import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = 'http://meitensaku-001-site1.gtempurl.com/api/category';

  constructor(private  http: HttpClient) { }

  public getCategories (): Observable<any> {
    return this.http.get(this.urlApi);
  }
}
