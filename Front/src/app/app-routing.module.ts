import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AllcategoryComponent } from './components/allcategory/allcategory.component';
import { ShoppingCartContentComponent } from './components/shopping-cart-content/shopping-cart-content.component';


const routes: Routes = [
  {path: 'Navbar', component: NavbarComponent},
  {path: 'Allcategory', component: AllcategoryComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
