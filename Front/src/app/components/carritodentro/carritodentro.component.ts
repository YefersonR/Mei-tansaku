import { Component } from '@angular/core';

interface CartItem {
  name: string;
  description: string;
  image: string;
  quantity: number;
  price: number;
  seller: string;
  shippingPrice: number;
}

@Component({
  selector: 'app-carritodentro',
  templateUrl: './carritodentro.component.html',
  styleUrls: ['./carritodentro.component.css']
})
export class CarritodentroComponent {
  cartItems: CartItem[] = [
    {
      name: "Producto 1",
      description: "Descripción del producto 1",
      image: "https://cdn.shopify.com/s/files/1/0472/0014/1462/products/WhatsAppImage2021-05-18at10.04.29_580x.jpg?v=1624135016",
      quantity: 1,
      price: 10,
      seller: "Vendedor 1",
      shippingPrice: 5
    },
    {
      name: "Producto 2",
      description: "Descripción del producto 2",
      image: "https://www.eurekakids.es/cdnassets/69185505-1_m.jpg",
      quantity: 2,
      price: 15,
      seller: "Vendedor 2",
      shippingPrice: 3
    },
    {
      name: "Producto 3",
      description: "Descripción del producto 3",
      image: "https://m.media-amazon.com/images/I/61VHoMGP46L.jpg",
      quantity: 3,
      price: 20,
      seller: "Vendedor 3",
      shippingPrice: 8
    }
  ];

  decreaseQuantity(item: CartItem): void {
    if (item.quantity > 1) {
      item.quantity--;
    }
  }

  increaseQuantity(item: CartItem): void {
    item.quantity++;
  }

  removeItem(item: CartItem): void {
    const index = this.cartItems.indexOf(item);
    if (index !== -1) {
      this.cartItems.splice(index, 1);
    }
  }

  calculateTotalQuantity(): number {
    let total = 0;
    for (const item of this.cartItems) {
      total += item.quantity;
    }
    return total;
  }

  calculateSubtotal(): number {
    let subtotal = 0;
    for (const item of this.cartItems) {
      subtotal += item.price * item.quantity;
    }
    return subtotal;
  }

  calculateShippingCost(): number {
    let shippingCost = 0;
    for (const item of this.cartItems) {
      shippingCost += item.shippingPrice;
    }
    return shippingCost;
  }

  calculateTotal(): number {
    return this.calculateSubtotal() + this.calculateShippingCost();
  }

  checkout(): void {
    // Implementa aquí la lógica para realizar el pedido
  }

  goToSavedItems(): void {
    // Implementa aquí la lógica para ir a la sección de "Guardar para más tarde"
  }
}
