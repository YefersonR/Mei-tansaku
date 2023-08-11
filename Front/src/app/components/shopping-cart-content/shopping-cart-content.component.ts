import { Component, OnInit } from '@angular/core';
import { productCart } from 'src/app/interfaces/productCart.interface';

@Component({
  selector: 'app-shopping-cart-content',
  templateUrl: './shopping-cart-content.component.html',
  styleUrls: ['./shopping-cart-content.component.css']
})
export class ShoppingCartContentComponent implements OnInit {
  carrito: productCart[] = [

  ];
  constructor() { }

  ngOnInit(): void {
    const carritoGuardado = localStorage.getItem('carrito');
    if (carritoGuardado) {
      this.carrito = JSON.parse(carritoGuardado);
      console.log(this.carrito)
    }
  }

}
