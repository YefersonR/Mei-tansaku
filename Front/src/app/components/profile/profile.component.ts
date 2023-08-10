import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  loggedInUserName: string = '';
  Roles: string = ''; // Agrega esta propiedad

  constructor(private router: Router) { }

  ngOnInit(): void {
    // Obtener el nombre de usuario del localStorage y asignarlo a la propiedad
    this.loggedInUserName = localStorage.getItem('name') || '';
    this.Roles = localStorage.getItem('roles') || '';
  }

  logout() {
    // Eliminar los datos del usuario del localStorage
    localStorage.removeItem('jwToken');
    localStorage.removeItem('name');
    localStorage.removeItem('roles');
    
    // Redirigir al componente de inicio de sesión
    this.router.navigateByUrl('/login');
  }

}