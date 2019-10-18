import { Component, OnInit } from '@angular/core';  //Decorator component
import { ProductService } from '../services/product/product.service';
import { Product } from '../model/product';
import { Router } from '@angular/router';
import { empty } from 'rxjs';


@Component({ //Configuração para funcionar como um component do angular
  selector: 'app-product', //Define o nome da tag(html) que o ProductComponent
  templateUrl: './product.component.html',//estrutura em html onde ira renderizar o component
  styleUrls: ['./product.component.css']
  

}) //Injeta dentro do ProductComponent o decorator component (Para fazer funcionar como um Component)

//export == public
export class ProductComponent implements OnInit {

  public product: Product;
  public selectedFile: File;
  public activeSpinner: boolean;
  public message: string;

  constructor(private productService: ProductService, private router: Router) {

  }

  ngOnInit(): void {
    //lê objeto armazenado na sessão do search product component e le pegando pela chave
    var productSession = sessionStorage.getItem('productSession');
    //verifica se tem valor e converte para TypeScript(JSON.parse)
    if (productSession) {
      this.product = JSON.parse(productSession);
    } else {
      
      this.product = new Product(); 
    }
  } 

  //FileList é do JS -- inputChange metodo a ser disparado no html para anexar arquivo
  public inputChange(files: FileList) {
    this.selectedFile = files.item(0);
    this.ActivateSpinner();
    
    this.productService.sendFile(this.selectedFile)
      .subscribe(
       
        data => {
          this.product.fileName = data;
         
          console.log(data);
          this.DisableSpinner();
          
        },
        e => {
          console.log(e.error);
          this.DisableSpinner();
        }
      );
  }

  public registerProduct() {
    this.ActivateSpinner();
    //this.product
    this.productService.registerProduct(this.product)
      .subscribe(
        productJson => {
          this.DisableSpinner();
          console.log(productJson);
          this.router.navigate(['/search-product']);
        },
        err => {
          this.DisableSpinner();
          console.log(err.error);
          this.message = err.error;
        }
      );
  }

  public cancel() {
    this.router.navigate(['/search-product']);
  }

  public ActivateSpinner() {
    this.activeSpinner = true;
  }

  public DisableSpinner() {
    this.activeSpinner = false;
  }
}
