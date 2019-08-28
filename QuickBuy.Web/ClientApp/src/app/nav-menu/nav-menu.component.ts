import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;


  constructor(private router: Router) {

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  userLogged(): boolean {
    /*var userLogged = sessionStorage.getItem('user-authenticated');
    if (userLogged == "1") {
      return true;
    }
    return false;*/

    return sessionStorage.getItem('user-authenticated') == '1';
  }

  exit() {
    sessionStorage.setItem('user-authenticated', "");
    this.router.navigate(['/']);
  }
}
