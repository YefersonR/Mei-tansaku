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

  isOpening = false;
  isOpen = false;
  categories: any[] = [];
  isDropdownOpen = false;
  isSidebarOpen = false;



  openDropdown() {
    this.isOpen = !this.isOpen;
  }

  openDropdownn() {
    this.isOpening = !this.isOpening;
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
    })
  }

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }


}
