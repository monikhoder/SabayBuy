import { CurrencyPipe } from '@angular/common';
import { Component, inject, OnInit, signal} from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { initFlowbite } from 'flowbite';
import { CartService } from '../../../core/services/cart.service';
import { ShopServices } from '../../../core/services/shop.service';
import { LoadingService } from '../../../core/services/loading.service';
import { Product } from '../../../shared/models/product';
import { ProductCardComponent } from '../product-list/product-card/product-card.component';
import { productParams } from '../../../shared/models/productParams';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CurrencyPipe, RouterLink, ProductCardComponent, MatIcon],
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
  imageUrl = signal<string[]>([]);
  similarProducts = signal<Product[]>([]);


  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: params => {
        const id = params.get('id');
        if (id) {
          this.loadProduct(id);
        }
      }
    });
  }

  loadProduct(id: string) {
    this.shopService.getProduct(id).subscribe({
      next: product => {
        this.product = product;
        this.loadImages();
        if (product.variants.length > 0) {
          this.variantChange(product.variants[0].id);
        }
        this.loadSimilarProducts();
        window.scrollTo(0, 0);
      },
      complete: () => {
        setTimeout(() => initFlowbite(), 100);
      },
      error: error => console.log(error)
    });
  }

  loadSimilarProducts() {
    if (!this.product) return;
    const params = new productParams();
    params.category = [this.product.categoryName];
    params.pageSize = 4;
    this.shopService.getProducts(params).subscribe({
      next: response => {
        this.similarProducts.set(response.data.filter(p => p.id !== this.product?.id));
      }
    });
  }

  loadImages() {
    if (!this.product) return;
    const images = new Set<string>();
    if (this.product.baseImageUrl) images.add(this.product.baseImageUrl);
    this.product.variants.forEach(v => {
      if (v.imageUrl) images.add(v.imageUrl);
    });
    this.imageUrl.set(Array.from(images));
  }

  variantChange(variantId: string) {
    this.variantId.set(variantId);
    const variant = this.product?.variants.find(v => v.id === variantId);
    if (variant) {
      this.price.set(variant.price);
    }
  }

  priceChange(price: number) {
    this.price.set(price);
  }

  nextImage() {
    if (this.currentImageIndex() < this.imageUrl().length) {
      this.currentImageIndex.update(i => i + 1);
    } else {
      this.currentImageIndex.set(1);
    }
  }

  prevImage() {
    if (this.currentImageIndex() > 1) {
      this.currentImageIndex.update(i => i - 1);
    } else {
      this.currentImageIndex.set(this.imageUrl().length);
    }
  }
}
