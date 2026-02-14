import { Component, inject, OnInit } from '@angular/core';
import { ShopServices } from '../../core/services/shop.services';
import { Product } from '../../shared/models/product';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  imports: [],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss',
})
export class ProductDetailsComponent implements OnInit {
  private shopService = inject(ShopServices);
  private activatedRoute = inject(ActivatedRoute);
  product? : Product;
  currentImageIndex = 1;
  price: number = 0;
  imageUrl: string[] = [
    '../slide/airpods.jpg',
    '../slide/airpods2.jpg',
    '../slide/airpods3.jpg'
  ];


  ngOnInit(): void {
    this.loadProduct();
    this.loadImage();

  }
  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) {
      return;
    }
    this.shopService.getProduct(id).subscribe({
      next: product => this.product = product,
      error: error => console.log(error)
    });
  }

  priceChange(price : number){
    this.price = price;
  }
  loadImage(){
   console.log(this.imageUrl);
  }

  incrementImageIndex() {
    if (this.currentImageIndex < this.imageUrl.length) {
      this.currentImageIndex++;
    } else {
      this.currentImageIndex = 1;
    }
  }
  deacreaseImageIndex() {
    if (this.currentImageIndex > 1) {
      this.currentImageIndex--;
    } else {
      this.currentImageIndex = this.imageUrl.length;
    }}
}

