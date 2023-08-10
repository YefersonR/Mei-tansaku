import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginObj: any = {
    userName: '',
    password: '',
  };

  errorMessage: string = ''; // Agrega esta propiedad

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {}

  onLogin() {
    console.log(this.loginObj);

    // Resetear el mensaje de error
    this.errorMessage = '';

    this.userService.onLogin(this.loginObj).subscribe(
      (res: any) => {
        console.log('res', res);

        if (res.payload.jwToken === null) {
          this.errorMessage = '**Las credenciales no existen';
        } else {
          const token = res.payload.jwToken;
          const name = res.payload.name; // Obtén el nombre de usuario
          const roles = res.payload.roles;
          
          localStorage.setItem('jwToken', token);
          localStorage.setItem('name', name); // Almacena el nombre de usuario
          localStorage.setItem('roles', roles);
          
          this.router.navigateByUrl('/');
        }
      },
      (error: any) => {
        // Mostrar el mensaje de error específico de la API en pantalla
        if (error.error.message) {
          this.errorMessage = error.error.message;
        }
      }
    );    
  }
}

