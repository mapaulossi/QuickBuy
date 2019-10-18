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
  public spinner_active: boolean;
  public message: string;
  public registerUser: boolean;

  constructor(private userService: UserService) {

  }

  ngOnInit(): void {//método de inicialização (padrão)
    this.user = new User();
  }

  public register() {

    this.spinner_active = true;
    this.userService.registerUser(this.user)
      .subscribe(
        userJson => {
          this.registerUser = true;
          this.message = "";
          this.spinner_active = false;

        },

        err => {
          this.registerUser = false;
          this.message = err.error;
          this.spinner_active = false;

        }
      );
  }

}
