import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;


  constructor(private router: Router, private userService: UserService) {

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  userLogged(): boolean {

    return this.userService.user_authenticated();
  }

  exit() {
    this.userService.clean_section();
    this.router.navigate(['/']);
  }
}
