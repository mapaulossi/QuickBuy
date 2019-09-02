import { Component, OnInit } from '@angular/core';  //Decorator component
import { ProductService } from '../services/product/product.service';
import { Product } from '../model/product';


@Component({ //Configuração para funcionar como um component do angular
  selector: 'app-product', //Define o nome da tag(html) que o ProductComponent
  templateUrl: './product.component.html',//estrutura em html onde ira renderizar o component
  styleUrls: ['./product.component.css']
  

}) //Injeta dentro do ProductComponent o decorator component (Para fazer funcionar como um Component)

//export == public
export class ProductComponent implements OnInit {

  public product: Product;

  constructor(private productService: ProductService) {

  }

  ngOnInit(): void {
    this.product = new Product();
  } 

  public registerProduct() {
    //this.product
    this.productService.registerProduct(this.product)
      .subscribe(
        productJson => {

        },
        err => {

        }
      );
  }
}
