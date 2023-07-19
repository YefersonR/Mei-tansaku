import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

interface Category {
  id: number;
  name: string;
  // Agrega aquí más propiedades si hay otras en tu modelo de categoría
}

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  selectedCategory: Category;

  constructor(private categoryService: CategoryService) { }
  
  ngOnInit(): void {
    this.fetchCategoryById(1);
  }

  fetchCategoryById(id: number): void {
    this.categoryService.getCategoryById(id).subscribe(category => {
      this.selectedCategory = category;
    });
  }
}
