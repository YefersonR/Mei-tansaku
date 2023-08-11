import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { AuthComponent } from './pages/auth/auth.component';
import { CategoryComponent } from './components/category/category.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AllcategoryComponent } from './components/allcategory/allcategory.component';
import { ServicioAlClienteComponent } from './components/servicioalcliente/servicioalcliente.component';
import { PaginaCategoriaComponent } from './components/paginacategoria/paginacategoria.component';
import { ListadeseosComponent } from './components/listadeseos/listadeseos.component';
import { CarritodentroComponent } from './components/carritodentro/carritodentro.component';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { BuscadorComponent } from './components/buscador/buscador.component';


const routes: Routes = [
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

    {path: 'navbar', component: NavbarComponent},
    {path: 'allcategory', component: AllcategoryComponent},
    {path: 'category.name', component: AllcategoryComponent},
    {path: 'product-page', component: ProductPageComponent},

  {
    path:'categoria/:id',
    component:PaginaCategoriaComponent
  },
  {
    path:'carrito',
    component:CarritodentroComponent
  },
  {
    path:'listadeseos',
    component:ListadeseosComponent
  },
  {
    path:'buscador',
    component:BuscadorComponent
  },
  {
    path:'help',
    component:ServicioAlClienteComponent
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

