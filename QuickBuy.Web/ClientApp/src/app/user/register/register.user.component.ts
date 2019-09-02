import { Component, OnInit } from '@angular/core';
import { User } from '../../model/user';
import { UserService } from '../../services/user/user.service';


@Component({
  selector: 'register-user',
  templateUrl: './register.user.component.html',
  styleUrls: ['./register.user.component.css']
})

export class RegisterUserComponent implements OnInit {
   
  public user: User;

  constructor(private userService: UserService) {

  }

  ngOnInit(): void {//método de inicialização (padrão)
    this.user = new User();
  }

  public register() {
    this.userService.registerUser(this.user)
      .subscribe(
        userJson => {

        },

        err => {

        }
      );
  }

}
