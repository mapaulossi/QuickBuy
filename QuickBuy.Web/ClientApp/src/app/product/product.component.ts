import { Component } from '@angular/core';  //Decorator component

@Component({ //Configuração para funcionar como um component do angular
  selector: 'app-product', //Define o nome da tag(html) que o ProductComponent
  template: '<html><body>{{ getName() }}</body></html>'//estrutura em html onde ira renderizar o component

}) //Injeta dentro do ProductComponent o decorator component (Para fazer funcionar como um Component)

//export == public
export class ProductComponent { 
  
  public name: string;
  public releasedForSale: boolean;

  public getName(): string {
    
    return "Xiaomi s2";

  }
}
