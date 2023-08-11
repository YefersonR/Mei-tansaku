import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-shop-by-category',
  templateUrl: './shop-by-category.component.html',
  styleUrls: ['./shop-by-category.component.css']
})
export class ShopByCategoryComponent implements OnInit {

  categories: any[] = [];
  displayedCategories: any[] = [];

  isDropdownOpen = false;

  constructor(private categoryService: CategoryService, private router: Router) { }

  ngOnInit(): void {
    this.fetchCategories();
    
  }


  fetchCategories() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories.slice(8, 20);
    })
  }
}
