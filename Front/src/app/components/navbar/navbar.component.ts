import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';
import { CartService } from 'src/app/services/cart.service';
import { productCart } from 'src/app/interfaces/productCart.interface';

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
  cart: productCart[];

  constructor(
    private categoryService: CategoryService,
    private cartService: CartService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.fetchCategories();
    this.cart = this.cartService.getCarrito();
  }

  fetchCategories() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
    });
  }

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  openDropdown() {
    this.isOpen = !this.isOpen;
  }

  openDropdownn() {
    this.isOpening = !this.isOpening;
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  irABuscador() {
    this.router.navigate(['/buscador']); // Cambia '/buscador' por la ruta real de tu componente "buscador"
  }
}
