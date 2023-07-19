import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isOpen = false;
  isContentHovered = false;
  showOptions: boolean = false;

  categoriess: any[] = [];
  categories: any[] = [];

  
  isDropdownOpen = false;


  toggleOptions() {
    this.showOptions = !this.showOptions;
  }

  openDropdown() {
    this.isOpen = !this.isOpen;
  }
  
  contentHovered() {
    this.isContentHovered = true;
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }


  constructor(private categoryService: CategoryService, private router: Router) { }
  

  ngOnInit(): void {
    this.fetchCategories();
    
  }
  

  fetchCategories() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
      console.log('Llamada a la API exitosa. Categorías obtenidas:', this.categories);
    })
  }
  
}