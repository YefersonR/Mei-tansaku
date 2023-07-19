import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private urlApi = 'http://meitensaku-001-site1.gtempurl.com/api/category';

  private apiUrl = 'http://meitensaku-001-site1.gtempurl.com/api/category/preview/';


  constructor(private  http: HttpClient) { }

  public getCategories (): Observable<any> {
    return this.http.get(this.urlApi);

  }

  public getCategoryById(id: number): Observable<any> {
    return this.http.get<any[]>(this.apiUrl + id).pipe(
      map(categories => categories.find(category => category.id === id))
    );
  }

}
