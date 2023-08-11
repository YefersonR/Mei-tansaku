import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../services/category.service';

interface Slide {
  imgSrc: string;
  alt: string;
}

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit{
  categories: any[] = [];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data.slice(14,31);

    })
  }
  currentSlideIndex: number = 0;

  prevSlide() {
    this.currentSlideIndex = (this.currentSlideIndex - 1 + this.categories.length) % this.categories.length;
  }

  nextSlide() {
    this.currentSlideIndex = (this.currentSlideIndex + 1) % this.categories.length;
  }
}
