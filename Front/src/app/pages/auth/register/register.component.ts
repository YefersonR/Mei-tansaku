import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public registerForm : FormGroup;
  type_accounts:string[] = ['personal','empresarial']
  selected_account :string;
  constructor(private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.selected_account = this.type_accounts[0];
    this.selectForm()
  }
  selectForm():any{
    if(this.selected_account == this.type_accounts[0]){
      this.registerForm = this.formBuilder.group({
        name:['',
        [
          Validators.required
        ]],
        lastName:['',
        [
          Validators.required
        ]],
        email:['',[
          Validators.required,
          Validators.email
        ]],
        password:['',[
          Validators.required
        ]]
      })
    }
    else if(this.selected_account == this.type_accounts[1]){
      this.registerForm = this.formBuilder.group({
        sellerName:['',
        [
          Validators.required
        ]],
        sellerEmail:['',
        [
          Validators.required,
          Validators.email
        ]],
        sellerPassword:['',[
          Validators.required
        ]],
        // country:['',[
        //   Validators.required
        // ]]
      })
    }
  }
  register():any{
    console.log(this.registerForm)
  }

}
