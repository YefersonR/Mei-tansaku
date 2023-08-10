import { Component, OnInit } from '@angular/core';

interface Slide {
  imgSrc: string;
  alt: string;
}

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent {
  slides: Slide[] = [
    { imgSrc: 'https://www.tooltyp.com/wp-content/uploads/2014/10/1900x920-8-beneficios-de-usar-imagenes-en-nuestros-sitios-web.jpg', alt: 'Slide 1' },
    { imgSrc: 'https://media.istockphoto.com/id/1017175098/es/foto/puesta-de-sol-en-la-savana.jpg?s=612x612&w=0&k=20&c=SR9fp6uXn9ldtKZAWAbQsOnO7i2P9yD9BR5mbKAIvNM=', alt: 'Slide 2' },
    { imgSrc: 'https://thumbs.dreamstime.com/b/tiro-de-arriba-de-la-materia-de-los-hombres-65390781.jpg', alt: 'Slide 3' },
    // Agregar más objetos de imágenes según sea necesario
  ];
  

  currentSlideIndex: number = 0;

  prevSlide() {
    this.currentSlideIndex = (this.currentSlideIndex - 1 + this.slides.length) % this.slides.length;
  }

  nextSlide() {
    this.currentSlideIndex = (this.currentSlideIndex + 1) % this.slides.length;
  }
}