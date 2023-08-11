import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Producto {
  id: number;
  name: string;
  imageUrl: string | null;
  description: string;
  price: number;
  rating: number;
}

@Component({
  selector: 'app-paginacategoria',
  templateUrl: './paginacategoria.component.html',
  styleUrls: ['./paginacategoria.component.css'],
})
export class PaginaCategoriaComponent implements OnInit {
  productos: Producto[] = [];
  productosFiltrados: Producto[] = [];
  precioMinimo: number = 0;
  precioMaximo: number = 0;
  ordenAlfabetico: 'asc' | 'desc' = 'asc';
  //  currentPage: number = 1;
  pageSize: number = 115; // Tamaño de cada página
  // totalPages: number = 1; // Número total de páginas
  categoryId: number = 19; // ID de la categoría (ajusta el valor según tu API)

  //////////////////////////////////////////////////////////////////////////////////////////
  items: any[] = [];
  itemsPerPage = 20;
  currentPage = 1;

  get totalItems(): number {
    return this.items.length;
  }

  get totalPages(): number {
    return Math.ceil(this.totalItems / this.itemsPerPage);
  }

  get paginatedItems(): any[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.items.slice(startIndex, endIndex);
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }
  //////////////////////////////////////////////////////////////////////////////////////////

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.obtenerProductos();
  }

  obtenerProductos() {
    const apiUrl = `http://meitensaku-001-site1.gtempurl.com/api/Category/products?iD=${this.categoryId}&page=${this.currentPage}&pageSize=${this.pageSize}`;
    this.http.get<any>(apiUrl).subscribe(
      (data) => {
        this.productos = data.previewProductItem;
        //this.totalPages = data.totalPages;
        this.filtrarProductos();
      },
      (error) => {
        console.error('Error al obtener los productos', error);
      }
    );
  }

  filtrarProductos() {
    this.productosFiltrados = this.productos.filter((producto) => {
      return (
        producto.price >= this.precioMinimo &&
        producto.price <= this.precioMaximo
      );
    });

    if (this.productosFiltrados.length > 0)
      this.items = this.productosFiltrados;
    else this.items = this.productos;

    this.ordenarProductos();
  }

  ordenarProductos() {
    if (this.ordenAlfabetico === 'asc') {
      this.productosFiltrados.sort((a, b) => a.name.localeCompare(b.name));
    } else {
      this.productosFiltrados.sort((a, b) => b.name.localeCompare(a.name));
    }
  }

  limpiarFiltro() {
    this.precioMinimo = 0;
    this.precioMaximo = 0;
    this.ordenAlfabetico = 'asc';
    this.currentPage = 1;
    this.obtenerProductos();
  }

  cambiarOrdenAlfabetico() {
    this.ordenAlfabetico = this.ordenAlfabetico === 'asc' ? 'desc' : 'asc';
    this.currentPage = 1;
    this.obtenerProductos();
  }

  goToPage(pageNumber: number) {
    if (pageNumber >= 1 && pageNumber <= this.totalPages) {
      this.currentPage = pageNumber;
      this.obtenerProductos();
    }
  }

  getPages(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  getProductosPaginados(): Producto[] {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.productosFiltrados.slice(startIndex, endIndex);
  }
}
