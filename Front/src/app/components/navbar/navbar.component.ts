import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ApiService } from 'src/app/service/api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isOpen = false;
  isContentHovered = false;
  showOptions: boolean = false;
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


  constructor(private apiService: ApiService, private router: Router) { }
  

  ngOnInit(): void {
    this.fetchCategories();
  }
  

  fetchCategories() {
    this.apiService.getCategories().subscribe(categories => {
      this.categories = categories;
      console.log('Llamada a la API exitosa. Categorías obtenidas:', this.categories);
    })
  }

  navegar (){
    this.router.navigate(['/allcategory']);
  }
  
}