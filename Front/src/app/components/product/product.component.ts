import { Component, OnInit } from '@angular/core';
import { products } from 'src/app/interfaces/product.interface';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products:products[]=[];

  constructor(private productService:ProductService) { }
  
  ngOnInit(): void{
  }

}
