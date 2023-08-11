import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private urlApi = 'http://meitensaku-001-site1.gtempurl.com/api/category';


  constructor(private  http: HttpClient) { }

  public getCategories (): Observable<any> {
    return this.http.get(this.urlApi);

  }
}
