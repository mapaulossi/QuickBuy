import { Component } from '@angular/core';

@Component({
  selector: 'app-root', //informa tag que Component principal sera renderizado (no caso AppComponent)
  templateUrl: './app.component.html', //O component do TS noa é renderizado é apenas resultado de compilação que esta dentro do html
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
}
