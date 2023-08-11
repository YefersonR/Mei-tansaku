import { Component, OnInit } from '@angular/core';
import { productCart } from 'src/app/interfaces/productCart.interface';
import { CartService } from './../../services/cart.service';

@Component({
  selector: 'app-shopping-cart-content',
  templateUrl: './shopping-cart-content.component.html',
  styleUrls: ['./shopping-cart-content.component.css']
})
export class ShoppingCartContentComponent implements OnInit {
  carrito: productCart[] = [
  ];
  total:number = 0
  Shipping:number =0;
  subTotal:number=0;
  constructor(private cartService:CartService) { }

  ngOnInit(): void {
    this.carrito = this.cartService.getCarrito()
    this.getTotal()
  }


  addProductToCart(product:productCart){
    this.cartService.addProductToCart(product)
    this.getTotal()

  }
  deleteProductToCart(product:productCart){
    this.cartService.deleteProductToCart(product)
    this.getTotal()
  }
  getTotal(){
    this.carrito.forEach(product=>{
      this.subTotal =+ product.price * product.quantity
    })
    this.Shipping = parseFloat((this.total * 0.10).toFixed(2));
    this.total = this.subTotal + this.Shipping
  }

}
