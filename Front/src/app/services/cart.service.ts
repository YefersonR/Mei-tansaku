import { Injectable } from '@angular/core';
import { productCart } from '../interfaces/productCart.interface';
import { products } from '../interfaces/product.interface';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  carrito: productCart[] = [

  ];

  constructor() { }

  addProductToCart(producto: productCart){
    const index = this.carrito.findIndex(item => item.id === producto.id);

    if (index !== -1) {
      this.carrito[index].quantity++;
    } else {
      this.carrito.push({ ...producto, quantity: 1 });
    }
    localStorage.setItem('carrito', JSON.stringify(this.carrito));

  }
  deleteProductToCart(producto: productCart){
    const index = this.carrito.findIndex(item => item.id === producto.id);

    if (index !== -1) {
      if (this.carrito[index].quantity > 1) {
        this.carrito[index].quantity--;
      } else {
        this.carrito.splice(index, 1);
      }
    }
    localStorage.setItem('carrito', JSON.stringify(this.carrito));

  }

}
