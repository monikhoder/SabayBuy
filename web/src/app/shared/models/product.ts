
export type VariantAttribute ={
  attributeName: string;
  attributeValue: string;
  createdAt: string;
  updatedAt: string;
}


export type ProductVariant  ={
  id: string;
  sku: string;
  price: number;
  stockQuantity: number;
  imageUrl?: string;
  createdAt: string;
  updatedAt: string;
  attributes: VariantAttribute[];
}


export type Product = {
  id: string;
  productName: string;
  description?: string;
  baseImageUrl?: string;
  brand: string;
  categoryName: string;
  price: number;
  createdAt: string;
  updatedAt: string;
  variants: ProductVariant[];
}
