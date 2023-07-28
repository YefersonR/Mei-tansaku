import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CategoryComponent } from './components/category/category.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { AuthComponent } from './pages/auth/auth.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import { LoadingComponent } from './components/loading/loading.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { CarritodentroComponent } from './components/carritodentro/carritodentro.component';
import { ServicioAlClienteComponent } from './components/servicioalcliente/servicioalcliente.component';
import { ShoppingCartContentComponent } from './components/shopping-cart-content/shopping-cart-content.component';
import { AllcategoryComponent } from './components/allcategory/allcategory.component';
import { ProductComponent } from './components/product/product.component';
import { ShopByCategoryComponent } from './components/shop-by-category/shop-by-category.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { ProductPageComponent } from './components/product-page/product-page.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoryComponent,
    HomeComponent,
    ShoppingCartContentComponent,
    AllcategoryComponent,
    LoginComponent,
    AuthComponent,
    RegisterComponent,
    LoadingComponent,
    FooterComponent,
    HeroDetailComponent,
    CarritodentroComponent,
    ServicioAlClienteComponent,
    ProductComponent,
    ShopByCategoryComponent,
    CarouselComponent,
    ProductPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
