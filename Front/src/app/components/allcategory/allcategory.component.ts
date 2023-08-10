import { ViewportScroller } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-allcategory',
  templateUrl: './allcategory.component.html',
  styleUrls: ['./allcategory.component.css']
})
export class AllcategoryComponent implements OnInit {

  categories: any[] = [];

  constructor(private http: HttpClient,  private viewportScroller: ViewportScroller) { }

  ngOnInit() {
    this.fetchCategories();
  }

  fetchCategories() {
    const apiUrl = 'http://meitensaku-001-site1.gtempurl.com/api/category';

    this.http.get<any[]>(apiUrl).subscribe(
      (response) => {
        this.categories = response;
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }
  scrollToAnchor(anchor: string): void {
    this.viewportScroller.scrollToAnchor(anchor);
  }

}
