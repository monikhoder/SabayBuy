
export interface VariantAttribute {
  attributeName: string;
  attributeValue: string;
  createdAt: string;
  updatedAt: string;
}


export interface ProductVariant {
  id: string;
  sku: string;
  price: number;
  stockQuantity: number;
  imageUrl?: string;
  createdAt: string;
  updatedAt: string;
  attributes: VariantAttribute[];
}


export interface Product {
  id: string;
  productName: string;
  description?: string;
  baseImageUrl?: string;
  brand: string;
  categoryName: string;
  createdAt: string;
  updatedAt: string;
  variants: ProductVariant[];
}
