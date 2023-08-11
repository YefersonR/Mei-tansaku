import { Component } from '@angular/core';
import { CartService } from './../../services/cart.service';
import { productCart } from 'src/app/interfaces/productCart.interface';

interface CartItem {
  name: string;
  description: string;
  image: string;
  quantity: number;
  price: number;
  seller: string;
  shippingPrice: number;
}

@Component({
  selector: 'app-carritodentro',
  templateUrl: './carritodentro.component.html',
  styleUrls: ['./carritodentro.component.css']
})
export class CarritodentroComponent {
  constructor(private cartService:CartService) { }
  carrito: productCart[] = [
  ];
  total:number = 0
  Shipping:number=0 ;
  subTotal:number=0
  ngOnInit(): void {
    this.carrito = this.cartService.getCarrito()
    this.getTotal()
  }

  addProductToCart(product:productCart){
    this.carrito = this.cartService.getCarrito()

    this.cartService.addProductToCart(product)
    this.getTotal()

  }
  deleteProductToCart(product:productCart){
    this.carrito = this.cartService.getCarrito()

    this.cartService.deleteProductToCart(product)
    this.getTotal()
  }
  getTotal(){
    this.carrito = this.cartService.getCarrito()

    this.carrito.forEach(product=>{
      this.subTotal =+ product.price * product.quantity
    })
    this.Shipping = parseFloat((this.total * 0.10).toFixed(2));
    this.total = this.subTotal + this.Shipping
  }
}
