import { Component, OnInit } from '@angular/core';
import { User } from '../../model/user';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public user;
  public returnUrl: string;

  constructor(private router: Router, private activatedRouter: ActivatedRoute) {
    this.user = new User();
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl']; //pega chave do save routes
  }

  enter() {

    if (this.user.email == "mt_paulossi@hotmail.com" && this.user.password == "123") {
      sessionStorage.setItem('user-authenticated', '1'); //salva variavel no local e se for autenticado fica com valor 1
      this.router.navigate([this.returnUrl]);//'/' = Home
    }
  }
}
