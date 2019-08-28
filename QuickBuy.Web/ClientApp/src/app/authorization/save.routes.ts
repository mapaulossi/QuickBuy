import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root' //classe SaveRoutes será publicada na raíz
})

export class SaveRoutes implements CanActivate {

  constructor(private router: Router) { //router injetado do app.module porcausa do @Injectable
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    var authenticated = sessionStorage.getItem('user-authenticated');  //localStoraged nativo do JS
    if (authenticated == "1") {
      return true;
    }
    //chama do ctor
    alert(state.url);
    this.router.navigate(['/enter'], { queryParams: { returnUrl: state.url } }); //queryParams configura pg de retorno
    return false;
  }
}


