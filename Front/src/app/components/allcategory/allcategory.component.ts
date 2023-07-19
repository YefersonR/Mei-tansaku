import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-allcategory',
  templateUrl: './allcategory.component.html',
  styleUrls: ['./allcategory.component.css']
})
export class AllcategoryComponent implements OnInit {

  categories: any[] = [];

  constructor(private categoryService : CategoryService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
      console.log('Llamada a la API exitosa. Categorías obtenidas ALLL:', this.categories);
    })
  }
  
}