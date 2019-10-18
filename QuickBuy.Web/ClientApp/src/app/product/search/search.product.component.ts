import { Component, OnInit } from "@angular/core";
import { Product } from "../../model/product";
import { ProductService } from "../../services/product/product.service";
import { Router } from "@angular/router";

@Component({
  selector: "search-product",
  templateUrl: "./search.product.component.html",
  styleUrls: ["./search.product.component.css"]
})

export class SearchProductComponent implements OnInit {


  public products: Product[];

  ngOnInit(): void {

  }

  constructor(private productService: ProductService, private router: Router) {
    this.productService.getAllProducts()
      .subscribe(
        products => {
          this.products = products
        },
        e => {
          console.log(e.error);
        });

  }

  public addProduct() {
    sessionStorage.setItem('productSession', "");
    this.router.navigate(['/add-product']);
    
  }

  public deleteProduct(product: Product) {
    var retorno = confirm("Do you really want to delete the selected product?");
    if (retorno == true) {
      this.productService.delete(product).subscribe(
        productsAfterDelete => {
          this.products = productsAfterDelete;
            
        }, e => {
          console.log(e.error);
        });
    }
  }

  public editProduct(product: Product) {
    //productSession acabeid e criar para este caso e convert para Json
    sessionStorage.setItem('productSession', JSON.stringify(product));
    this.router.navigate(['/add-product']);

  }

}
