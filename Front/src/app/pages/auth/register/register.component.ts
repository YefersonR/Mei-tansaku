import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  signupObj = {
    name: '',
    lastName: '',
    email: '',
    userName: '',
    password: '',
    confirmPassword: '',
    phone: ''
  };

  type_accounts: string[] = ['personal', 'empresarial'];
  selected_account: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.selected_account = this.type_accounts[0];
  }

  onRegister(): void {
    console.log(this.signupObj);
    this.userService.onRegister(this.signupObj).subscribe(
      (res: any) => {
        console.log('Registro exitoso', res);
        localStorage.setItem('jwToken', res.token);
      },
      (error: any) => {
        console.error('Error en el registro', error);
        console.log('Detalles del error de validación:', error.error.errors);
      }
    );
  }
}

// ferr
// ferwis12345