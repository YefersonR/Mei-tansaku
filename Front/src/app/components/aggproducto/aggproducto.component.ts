import { Component } from '@angular/core';

interface Producto {
  nombre: string;
  precio: number;
  descripcion: string;
  direccion: string;
  tamano: string;
  stock: number;
  categoria: string;
  imagen: string; // Agregamos la propiedad imagen
}

@Component({
  selector: 'app-aggproducto',
  templateUrl: './aggproducto.component.html',
  styleUrls: ['./aggproducto.component.css']
})
export class AggProductoComponent {
  producto: Producto = {
    nombre: '',
    precio: 0,
    descripcion: '',
    direccion: '',
    tamano: '',
    stock: 0,
    categoria: '',
    imagen: '' // Inicializamos la propiedad imagen
  };

  // Método para cargar la imagen
  cargarImagen(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.producto.imagen = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }

  // Limpiar todos los campos
  limpiarCampos() {
    this.producto = {
      nombre: '',
      precio: 0,
      descripcion: '',
      direccion: '',
      tamano: '',
      stock: 0,
      categoria: '',
      imagen: ''
    };
  }

  // Opcional: Lógica para agregar el producto
  agregarProducto() {
    // Implementa aquí la lógica para agregar el producto si es necesario
  }
}
