import { Component, inject, OnInit, signal} from '@angular/core';
import { ShopServices } from '../../core/services/shop.service';
import { Product } from '../../shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { LoadingService } from '../../core/services/loading.service';
import { initFlowbite } from 'flowbite';
import { CartService } from '../../core/services/cart.service';

@Component({
  selector: 'app-product-details',
  imports: [],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss',
})
export class ProductDetailsComponent implements OnInit {
  private shopService = inject(ShopServices);
  cartService = inject(CartService);
  private activatedRoute = inject(ActivatedRoute);
  loadingServeice = inject(LoadingService)
  product?: Product;
  variantId = signal<string>('');
  currentImageIndex = signal(1);
  price = signal(0);
  imageUrl: string[] = [
    'https://www.apple.com/v/macbook-pro/av/images/overview/welcome/hero_endframe__e4ls9pihykya_xlarge.jpg',
    'https://images-cdn.ubuy.co.in/651d959734ba4a33462ae371-apple-macbook-air-laptop-13-3-intel-core.jpg',
    'https://i.ebayimg.com/images/g/EGUAAOSwSWhjxdjA/s-l1200.jpg'
  ];


  ngOnInit(): void {
    initFlowbite();
    this.loadProduct();
  }
  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) {
      return;
    }
    this.shopService.getProduct(id).subscribe({
      next: product => this.product = product,
      complete: () => this.variantChange(this.product?.variants[0].id ?? ''),
      error: error => console.log(error)
    });
  }

   variantChange(variantId: string) {
    this.variantId.set(variantId);
    this.priceChange(this.product?.variants.find(v => v.id === variantId)?.price ?? 0);
  }
   priceChange(price: number) {
    this.price.set(price);
  }

   incrementImageIndex() {
    if (this.currentImageIndex() < this.imageUrl.length) {
      this.currentImageIndex.set(this.currentImageIndex() + 1);
    } else {
      this.currentImageIndex.set(1);
    }
  }
  deacreaseImageIndex() {
    if (this.currentImageIndex() > 1) {
      this.currentImageIndex.set(this.currentImageIndex() - 1);
    } else {
      this.currentImageIndex.set(this.imageUrl.length);
    }
  }
}

