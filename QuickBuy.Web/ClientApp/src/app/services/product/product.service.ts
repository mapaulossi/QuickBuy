import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../model/product';


@Injectable({
  providedIn: 'root'
})

export class ProductService implements OnInit{
    
  private _baseUrl: string;
  public products: Product[];

  //@Inject('BASE_URL') endereço raiz do site
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.products = []; 
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  public registerProduct(product: Product): Observable<Product> {
    //JSON.stringify(product) entra no lugar do body com as infos (Convertendo produto em JSON)
    return this.http.post<Product>(this._baseUrl + 'api/product/register', JSON.stringify(product), ({ headers: this.headers }));
  }

  public save(product: Product): Observable<Product> {

    return this.http.post<Product>(this._baseUrl + 'api/product/save', JSON.stringify(product), { headers: this.headers });

  }

  public delete(product: Product): Observable<Product> {

    return this.http.post<Product>(this._baseUrl + 'api/product/delete', JSON.stringify(product), { headers: this.headers });

  }

  public getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this._baseUrl + 'api/product/getAll');
  }

  public getProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(this._baseUrl + 'api/product/getProduct');
  }

}
