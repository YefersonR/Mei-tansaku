import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/interfaces/product.interface';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  categoryData: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    const apiUrl = 'http://meitensaku-001-site1.gtempurl.com/api/Category/products';
    const params = {
      iD: '1',
      page: '1',
      pageSize: '4'
    };

    this.http.get(apiUrl, { params }).subscribe((response: any) => {
      this.categoryData = response;
    });
  }
}