import { Component, OnInit } from '@angular/core';
import { User } from '../../model/user';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    
  public user;
  public returnUrl: string;
  public message: string;
  private spinner_active: boolean;

  constructor(private router: Router, private activatedRouter: ActivatedRoute,
    private userService: UserService) {
    //fica apenas para referenciar classes a serem injetadas
    
  }

  ngOnInit(): void { //Referencia quando a classe(componente) será inicializada
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl']; //pega chave do save routes
    this.user = new User();
  } 

  enter() {

    this.spinner_active = true;
    //Interessador no observable
    //subscribe faz a inscrição dos interessados e inicia o ASP NET Core (Web API)
    this.userService.checkUser(this.user)
      .subscribe(
        //Tratamento do retorno do serviço
        //data é retornado no caso sem erros
        //retorna o json do User (classe do Domain)

        user_json => {
          
          this.userService.user = user_json;

          if (this.returnUrl == null) {
            this.router.navigate(['/']);
          } else {
            this.router.navigate([this.returnUrl]);
          }
          
        },

        err => {
          console.log(err.error);
          this.message = err.error;
          this.spinner_active = false;
        }
      ); 

    /*if (this.user.email == "mt_paulossi@hotmail.com" && this.user.password == "123") {
      sessionStorage.setItem('user-authenticated', '1'); //salva variavel no local e se for autenticado fica com valor 1
      this.router.navigate([this.returnUrl]);//'/' = Home
    }*/
  }
}
