import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Cart, CartItem } from '../../shared/models/cart';
import { Product } from '../../shared/models/product';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl ;
  private http = inject(HttpClient)
  cart = signal<Cart | null> (null);
  cartCount = computed(() => this.cart()?.items.reduce((total, item) => total + item.quantity, 0) ?? 0);
  cartTotal = computed(() => this.cart()?.items.reduce((total, item) => total + item.price * item.quantity, 0) ?? 0);
  discount = computed(() => this.cartTotal() > 100 ? 5 : 0);
  saving = computed(() => this.cartTotal() * this.discount() / 100);
  deliveryFee = computed(() => this.cartCount() > 0 ? 2 : 0);
  total = computed(() => this.cartTotal() + this.deliveryFee() - this.saving());


  getCart(id: string){
    return this.http.get<Cart>(this.baseUrl + 'cart?id=' + id).pipe(
      map(cart => {
        this.cart.set(cart);
        return cart;
      })
    )
  }
  setCart(cart: Cart){
    return this.http.post<Cart>(this.baseUrl + 'cart' , cart).subscribe({
      next: cart => this.cart.set(cart)
    })
  }

  addItemToCart(item: CartItem | Product, variantId: string, increase = 1, quantity?: string){
    const cart = this.cart() ?? this.createCart()
    if(this.isProduct(item)){
      item = this.mapProductToCartItem(item, variantId);
    }
    cart.items = this.addOrUpdateItem(cart.items, item, variantId, increase, quantity);
    this.setCart(cart);
  }
  
  
  private addOrUpdateItem(items: CartItem[], item: CartItem, variantId: string, increase: number, quantity?: string): CartItem[] {
    const index = items.findIndex(x => x.productId === item.productId && x.productVariantId === variantId);
    if(quantity != null && this.isNumber(quantity)){
      if(parseInt(quantity) < 1){
        quantity = '1';
      }
      if(index === -1){
        item.quantity = parseInt(quantity);
        items.push(item);
      }else{
        items[index].quantity = parseInt(quantity);
      }
    }else{
      if(index === -1){
        item.quantity = increase;
        items.push(item);
      }else{
        items[index].quantity += increase;
      }
    }
    return items;
  }
  private isNumber(value: string | undefined): boolean {
    if (value === undefined) {
      return false;
    }
    const parsed = parseInt(value, 10);
    return isNaN(parsed) ? false : true;
  }
  removeItemFromCart(productId: string, variantId: string){
    const cart = this.cart() ?? this.createCart()
    cart.items = this.removeItem(cart.items, productId, variantId);
    this.setCart(cart);
  }
 private  removeItem(items: CartItem[], productId: string, variantId: string): CartItem[] {
    return items.filter(x => x.productId !== productId || x.productVariantId !== variantId);
  }
  private mapProductToCartItem(item: Product, variantId: string): CartItem {
    return {
      productId: item.id,
      productName: item.productName,
      price: item.price,
      imageUrl: item.variants.find(x => x.id === variantId)?.imageUrl ?? item.baseImageUrl!,
      quantity: 0,
      productVariantName: this.listattributes(item, variantId),
      productVariantId: variantId,
      brand: item.brand,
      category: item.categoryName
    };
  }
  private listattributes(item: Product, variantId: string): string {
    return item.variants.find(x => x.id === variantId)?.attributes.map(x => `${x.attributeName}: ${x.attributeValue}`).join(',') ?? '';
  }

  private isProduct(item: CartItem | Product) : item is Product{
    return (item as Product).id !== undefined;
  }
  private createCart(): Cart{
    const cart = new Cart();
    localStorage.setItem('cart_id' , cart.id);
    return cart;
  }
  
}
