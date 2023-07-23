import { Component, OnInit, HostListener } from '@angular/core';
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
      this.categories = categories.slice(0, 9);
      console.log('Llamada a la API exitosa. Categorías obtenidas:', this.categories);
    })
  }


  activeCategoryIndex: number = 0;

  // Función para manejar el evento de scroll
  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {
    this.updateActiveCategory();
  }


  updateActiveCategory() {
    const categoryElements = document.querySelectorAll('.category-item');
    const scrollPosition = window.scrollY;

    // Iteramos por los elementos de la lista para encontrar la categoría activa
    categoryElements.forEach((element, index) => {
      const elementTop = element.getBoundingClientRect().top;
      if (elementTop <= 150) {
        this.activeCategoryIndex = index;
      }
    });
  }
}
