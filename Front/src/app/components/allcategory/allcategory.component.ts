import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-allcategory',
  templateUrl: './allcategory.component.html',
  styleUrls: ['./allcategory.component.css']
})
export class AllcategoryComponent implements OnInit {

  categories: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories() {
    this.apiService.getCategories().subscribe(categories => {
      this.categories = categories;
      console.log('Llamada a la API exitosa. Categorías obtenidas:', this.categories);
    })
  }
  
}