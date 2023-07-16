import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public formLogin :FormGroup;
  constructor(private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      user:['',
      [
        Validators.required,
        Validators.minLength(4)
      ]],
      password:['',
      [
        Validators.required,
        Validators.minLength(8)
      ]]
    })

  }

  login():any{
    console.log(this.formLogin.get('user')?.touched)
  }
}
