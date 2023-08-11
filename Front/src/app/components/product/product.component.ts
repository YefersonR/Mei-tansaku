import { HttpClient } from '@angular/common/http';
import { Component, OnInit , Input } from '@angular/core';
import { Product } from 'src/app/interfaces/product.interface';
import { productCart } from 'src/app/interfaces/productCart.interface';
import { CartService } from './../../services/cart.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  categoryData: any;
  @Input() idCategory: number;


  constructor(private http: HttpClient,private cartService:CartService) { }

  ngOnInit(): void {
    const apiUrl = 'http://meitensaku-001-site1.gtempurl.com/api/Category/products';
    const params = {
      iD: this.idCategory,
      page: '1',
      pageSize: '4'
    };

    this.http.get(apiUrl, { params }).subscribe((response: any) => {
      this.categoryData = response;
    });
  }
  addToCart(product:Product){
    const productToCart: productCart = {
      id: product.id,
      name: product.name,
      imagenUrl: product.imageUrl!,
      description: product.description,
      price: product.price,
      rating: product.rating,
      quantity: 1
    };
    this.cartService.addProductToCart(productToCart)
  }
}
