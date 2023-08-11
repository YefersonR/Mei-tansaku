import { Component, OnInit } from '@angular/core';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-buscador',
  templateUrl: './buscador.component.html',
  styleUrls: ['./buscador.component.css']
})
export class BuscadorComponent implements OnInit {
  searchTerm: string = '';
  searchResults: any[] = [];
  currentPage: number = 1;
  pageSize: number = 20;
  totalPages: number = 0;
  displayedProducts: any[] = [];
  filterMinPrice: number | null = null;
  filterMaxPrice: number | null = null;
  isFiltering: boolean = false;

  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
    // Realizar la búsqueda inicial al cargar la página
    this.searchProducts();
  }

  searchProducts() {
    if (this.searchTerm.trim() !== '') {
      this.searchService.searchProducts(this.searchTerm,).subscribe((data: any) => {
        this.searchResults = data.searchPreviewProductItemDTO;

        // Calcular el número total de páginas
        this.totalPages = Math.ceil(this.searchResults.length / this.pageSize);

        // Mostrar los productos de la página actual
        this.changePage(0);
      });
    }
  }

  changePage(direction: number) {
    const nextPage = this.currentPage + direction;
    if (nextPage >= 1 && nextPage <= this.totalPages) {
      this.currentPage = nextPage;

      let filteredResults = this.searchResults;

      if (this.isFiltering) {
        filteredResults = this.searchResults.filter((product) => {
          if (this.filterMinPrice !== null && product.price < this.filterMinPrice) {
            return false;
          }
          if (this.filterMaxPrice !== null && product.price > this.filterMaxPrice) {
            return false;
          }
          return true;
        });
      }

      const startIndex = (this.currentPage - 1) * this.pageSize;
      const endIndex = Math.min(startIndex + this.pageSize, filteredResults.length);
      this.displayedProducts = filteredResults.slice(startIndex, endIndex);
    }
  }

  toggleDetails(product: any) {
    // Implementar la lógica para mostrar/ocultar detalles
  }

  addToCart(product: any) {
    // Implementar la lógica para agregar al carrito
  }

  addToFavorites(product: any) {
    // Implementar la lógica para agregar a favoritos
  }

  applyPriceFilter() {
    this.isFiltering = true;
    this.currentPage = 1;
    this.changePage(0);
  }

  clearPriceFilter() {
    this.isFiltering = false;
    this.filterMinPrice = null;
    this.filterMaxPrice = null;
    this.currentPage = 1;
    this.changePage(0);
  }
}
