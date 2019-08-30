import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserService } from '../services/user/user.service';

@Injectable({
  providedIn: 'root' //classe SaveRoutes será publicada na raíz
})

export class SaveRoutes implements CanActivate {

  constructor(private router: Router, private userService: UserService) { //router injetado do app.module porcausa do @Injectable
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    if (this.userService.user_authenticated()) {
      return true;
    }

    //chama do ctor
    
    this.router.navigate(['/enter'], { queryParams: { returnUrl: state.url } }); //queryParams configura pg de retorno
    return false;
  }
}


