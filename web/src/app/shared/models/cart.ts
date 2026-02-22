import { nanoid } from "nanoid";

export type CartType = {
    id: string;
    items: CartItem[];
    
}

export type CartItem = {
    productName: string;
    productId: string;
    productVariantName: string;
    productVariantId: string;
    price: number;
    quantity: number;
    imageUrl: string;
    brand: string;
    category: string;
}

export class Cart implements CartType {
    id = nanoid();
    items: CartItem[] = [];
}



