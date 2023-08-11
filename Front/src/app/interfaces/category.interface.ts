import { Product } from './product.interface';

export interface Category {
  nameCategory: string;
  productsQuantity: number;
  previewProductItem: Product[];
}
