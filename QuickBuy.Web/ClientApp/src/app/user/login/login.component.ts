import { Component } from '@angular/core';
import { User } from '../../model/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public user;
  public autenticatedUser: boolean;

  constructor() {
    this.user = new User();
  }

  enter() {

    if (this.user.email == "mt_paulossi@hotmail.com" && this.user.password == "123") {
      this.autenticatedUser = true;
    }
  }
}
