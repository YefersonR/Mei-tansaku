import { productCart } from './../../interfaces/productCart.interface';
import { CartService } from './../../services/cart.service';
import { productDetails } from './../../interfaces/productDetail.interface';
import { ProductService } from 'src/app/services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  id: number;
  productDetails:productDetails;


  constructor(private productService:ProductService,private cartService:CartService ,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    });
    this.getProduct()
  }
  getProduct(){
    this.productService.getProduct(this.id).subscribe(
      data=>{
        this.productDetails = data
        console.log("Detalles")
        console.log(this.productDetails)
      },error=>{
        console.error(error);
      }
    )
  }
  addToCart(){
    const productToCart: productCart = {
      id: this.productDetails.id,
      name: this.productDetails.name,
      imagenUrl: this.productDetails.product_Images[0],
      description: this.productDetails.description,
      price: this.productDetails.price,
      rating: this.productDetails.rating,
      quantity: 1
    };
    this.cartService.addProductToCart(productToCart)
  }

}
