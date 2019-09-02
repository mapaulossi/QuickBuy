import { Injectable, Inject } from '@angular/core'; //Para criar classe e configurar para injetar em outra classe
import { HttpClient, HttpHeaders } from '@angular/common/http'; //HttpClient faz requisição web, HttpHeaders cabeçalho para a requisição
import { Observable } from 'rxjs'; //bliblioteca p/ programação reativa (será o modo de chamadas(requisições) assincronas);
import { User } from '../../model/user';



//Decorator
@Injectable({
  providedIn: 'root'
})

export class UserService {

  private baseURl: string;
  private _user: User;

  get user(): User {
    let user_json = sessionStorage.getItem('user-authenticated');
    this._user = JSON.parse(user_json);
    return this._user;
  }
  set user(user: User) {
    sessionStorage.setItem('user-authenticated', JSON.stringify(user));
    this._user = user;
  }

  public user_authenticated(): boolean {
    return this._user != null && this._user.email != "" && this._user.password != "";
  }

  public clean_section() {
    sessionStorage.setItem('user-authenticated', "");
    this._user = null;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURl = baseUrl;
  }

  public checkUser(user: User): Observable<User> { //(LOJA)verifica o user e retorna observable

    const headers = new HttpHeaders().set('content-type', 'application/json'); //formato que vai trafegar na requisição

    //Json
    var body = {
      email: user.email,
      password: user.password
    }
    //this.baseURl = raíz do site ex: http://www.quickybuy.com/ e concatena com endereço do serviço
    return this.http.post<User>(this.baseURl + "api/user/CheckUser", body, { headers }); //sem nada pega post padrão

  }

  public registerUser(user: User): Observable<User> {

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: user.email,
      password: user.password,
      name: user.name,
      lastName: user.lastName
    }

    return this.http.post<User>(this.baseURl + "api/user", body, { headers })
  }
}

