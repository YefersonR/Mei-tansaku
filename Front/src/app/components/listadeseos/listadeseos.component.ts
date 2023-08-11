import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-listadeseos',
  templateUrl: './listadeseos.component.html',
  styleUrls: ['./listadeseos.component.css']
})
export class ListadeseosComponent implements OnInit {
  listaDeseos: any[] = [];
  carrito: any[] = [];
  busqueda: string = '';
  mostrarVistaRapida: boolean = false;
  productoSeleccionado: any = null;

  // Variable para almacenar la URL base de la API y el ID dinámico
  apiBaseUrl = 'http://meitensaku-001-site1.gtempurl.com/api/ShoppingList/GetList/';
  apiId: number = 0; // Inicializamos en 0

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.obtenerListaDeseos(); // Al iniciar el componente, obtenemos la lista de deseos
  }

  obtenerListaDeseos() {
    // Obtenemos el ID automáticamente desde la API
    this.http.get<number>('http://meitensaku-001-site1.gtempurl.com/api/GetDynamicId')
      .subscribe(
        (response) => {
          this.apiId = response; // Actualizamos el ID de la API con el valor recibido
          const url = `${this.apiBaseUrl}${this.apiId}`; // Construimos la URL completa
          this.http.get<any[]>(url).subscribe(
            (data) => {
              this.listaDeseos = data; // Actualizamos la lista de deseos con los datos obtenidos
            },
            (error) => {
              console.error('Error al obtener la lista de deseos:', error);
            }
          );
        },
        (error) => {
          console.error('Error al obtener el ID dinámico:', error);
        }
      );
  }

  eliminarDeListaDeseos(item: any) {
    const index = this.listaDeseos.findIndex((producto) => producto.id === item.id);
    if (index !== -1) {
      this.listaDeseos.splice(index, 1);
    }
  }

  agregarAlCarrito(item: any) {
    const index = this.carrito.findIndex((producto) => producto.id === item.id);
    if (index === -1) {
      this.carrito.push({ ...item, cantidad: 1 });
    } else {
      this.carrito[index].cantidad++;
    }
  }

  buscarArticulos() {
    if (this.busqueda.trim() !== '') {
      const busquedaMinuscula = this.busqueda.toLowerCase();
      this.listaDeseos = this.listaDeseos.filter((item) =>
        item.nombre.toLowerCase().includes(busquedaMinuscula) ||
        item.descripcion.toLowerCase().includes(busquedaMinuscula)
      );
    } else {
      this.restaurarListaDeseos();
    }
  }

  restaurarListaDeseos() {
    this.obtenerListaDeseos(); // Carga la lista original de deseos desde el endpoint
  }

  vaciarListaDeseos() {
    this.listaDeseos = [];
  }

  comprar() {
    // Lógica para procesar la compra de todos los elementos en el carrito de compras
    // Puedes implementar la lógica para comunicarte con un servidor o realizar alguna acción específica.
  }

  mostrarVistaRapidaProducto(item: any) {
    this.productoSeleccionado = item;
    this.mostrarVistaRapida = true;
  }

  cerrarVistaRapida() {
    this.mostrarVistaRapida = false;
  }

  compartirProducto(item: any) {
    const mensaje = `¡Mira este producto en mi lista de deseos!\n\nNombre: ${item.nombre}\nPrecio: ${item.precio}\nDescripción: ${item.descripcion}\n\nEnlace: ${window.location.href}`;
    if (navigator.share) {
      navigator.share({
        title: 'Producto de mi lista de deseos',
        text: mensaje,
      }).then(() => {
        console.log('Producto compartido con éxito.');
      }).catch((error) => {
        console.error('Error al compartir el producto:', error);
      });
    } else {
      prompt('Copie el enlace a continuación:', window.location.href);
    }
  }
}
