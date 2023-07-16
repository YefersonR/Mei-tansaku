import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AllcategoryComponent } from './components/allcategory/allcategory.component';
import { ShoppingCartContentComponent } from './components/shopping-cart-content/shopping-cart-content.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { AuthComponent } from './pages/auth/auth.component';
import { CategoryComponent } from './components/category/category.component';

const routes: Routes = [
  {path: 'Navbar', component: NavbarComponent},
  {path: 'Allcategory', component: AllcategoryComponent},

  {
    path:'auth',
    component:AuthComponent,
    children:[
      {
        path:'login',
        component:LoginComponent
      },
      {
        path:'signup',
        component:RegisterComponent
      },
      {
        path:'**',
        component:LoginComponent
      }
    ]
  },
  {
    path:'',
    component:HomeComponent,
    children:[
      {
        path:'**',
        component:CategoryComponent
      }
    ],
    pathMatch:'full'
  },
  {
    path:'**',
    component:HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

