import { Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { ShopServices } from '../../../core/services/shop.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { productParams } from '../../../shared/models/productParams';
import { Product } from '../../../shared/models/product';
import { Pagination } from '../../../shared/models/pagination';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { AddProductDialogComponent } from './add-product-dialog/add-product-dialog.component';
import { DeleteProductDialogComponent, DeleteDialogData } from './delete-product-dialog/delete-product-dialog.component';
import { AddVarientDialogComponent } from './add-varient-dialog/add-varient-dialog.component';
import { UpdateVarientDialogComponent } from './update-varient-dialog/update-varient-dialog.component';
import { UpdateProductDialogComponent } from './update-product-dialog/update-product-dialog.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Category } from '../../../shared/models/category';
import { categoryParams } from '../../../shared/models/categoryParams';
import { BrandGroup, FilterComponent } from '../../Shopping/product-list/filter/filter.component';
import { SortComponent } from '../../Shopping/product-list/sort/sort.component';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { AdminService } from '../../../core/services/admin.service';
import { AdminSearchComponent } from '../shared/admin-search/admin-search.component';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule, MatMenuModule, MatButtonModule, MatPaginatorModule,MatSlideToggleModule, MatDialogModule, MatIconModule, FilterComponent, SortComponent, AdminSearchComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss',
})
export class ProductsComponent implements OnInit{
  @ViewChild('filterComponent') filterComponent!: FilterComponent;
  @ViewChild('sortComponent') sortComponent!: SortComponent;

  shopService = inject(ShopServices);
  adminService = inject(AdminService);
  snack = inject(SnackbarService)
  dialog = inject(MatDialog)
  productParams = new productParams();
  categories: Category[] = [];
  categoryParams = new categoryParams;
  Products = signal<Product[]>([]);
  brands = signal<string[]>([]);
  groupedBrands: BrandGroup[] = [];
  totalItems = 0;
  totalProductCount = 0;
  expandedProductId: any = null;

  ngOnInit(): void {
    this.getProducts();
    this.getTotalProductCount();
    this.getCategories();
    this.getBrand();

  }

  toggleProduct(productId: any) {
    this.expandedProductId = this.expandedProductId === productId ? null : productId;
  }

  toggleProductStatus(product: Product) {
    this.adminService.updateProductStatus(product.id).subscribe({
      next: () => {
        product.isActive = !product.isActive;
        this.snack.success('Product status updated successfully');
      },
      error: (error) => this.snack.error(error.message || 'Failed to update product status')
    });
  }

  getProducts(){
    this.shopService.getProducts(this.productParams).subscribe({
        next: (response: Pagination<Product>) => {
                this.Products.set(response.data)
                this.totalItems = response.count;
              },
              error: (error) => this.snack.error(error.message)
    })
  }

  getTotalProductCount() {
    const totalParams = new productParams();
    totalParams.pageSize = 1;

    this.shopService.getProducts(totalParams).subscribe({
      next: (response: Pagination<Product>) => {
        this.totalProductCount = response.count;
      },
      error: (error) => this.snack.error(error.message)
    });
  }

  getCategories(){
     this.categoryParams.isParent = true;
    this.shopService.getCategories(this.categoryParams).subscribe({
      next: response => {
        this.categories = response.data
          .map(category => ({
            ...category,
            subCategories: category.subCategories.filter(subcategory => subcategory.productCount > 0)
          }))
          .filter(category => category.productCount > 0 || category.subCategories.length > 0);
      }
    })

  }

  getBrand(){
     this.shopService.getBrands().subscribe({
      next: (response) => {
        this.brands.set(response);
        this.groupBrands();
      }
    });
  }

  groupBrands() {
    const groups: { [key: string]: string[] } = {};

    this.brands().forEach(brand => {
      const firstLetter = brand.charAt(0).toUpperCase();

      if (!groups[firstLetter]) {
        groups[firstLetter] = [];
      }
      groups[firstLetter].push(brand);
    });
    this.groupedBrands = Object.keys(groups)
      .sort()
      .map(letter => ({
        letter: letter,
        brands: groups[letter]
      }));
  }

  handleBrandFilter(brands: string[]) {
    this.productParams.brand = brands;
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  handleCategoryFilter(categories: string[]) {
    this.productParams.category = categories;
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  HandleSortChange(sortValue: string) {
    this.productParams.sort = sortValue;
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  removeBrandFilter(brand: string) {
    this.productParams.brand = this.productParams.brand.filter(b => b !== brand);
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  removeCategoryFilter(category: string) {
    this.productParams.category = this.productParams.category.filter(c => c !== category);
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  resetAllFilters() {
    this.productParams.brand = [];
    this.productParams.category = [];
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  loadProductsFilter() {
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  onSearch(value: string) {
    this.productParams.search = value;
    this.productParams.pageIndex = 1;
    this.getProducts();
  }

  handlePageEvent(event: any) {
    this.productParams.pageIndex = event.pageIndex + 1; // MatPaginator is 0-based
    this.productParams.pageSize = event.pageSize;
    this.getProducts();
  }

  openAddProductDialog(){
     const dialogRef = this.dialog.open(AddProductDialogComponent, {
          width: '500px',
          disableClose: true
        });

     dialogRef.afterClosed().subscribe(result => {
       if (result) {
         this.getProducts();
         this.getTotalProductCount();
       }
     });
  }

  openUpdateProductDialog(product: Product) {
    const dialogRef = this.dialog.open(UpdateProductDialogComponent, {
      width: '500px',
      data: product,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getProducts();
      }
    });
  }

  openAddVariantDialog(product: Product) {
    const dialogRef = this.dialog.open(AddVarientDialogComponent, {
      width: '500px',
      data: product,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getProducts();
      }
    });
  }

  openUpdateVariantDialog(variant: any, product: Product) {
    const dialogRef = this.dialog.open(UpdateVarientDialogComponent, {
      width: '500px',
      data: { variant, productName: product.productName },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getProducts();
      }
    });
  }

  openDeleteDialog(id: string, type: 'product' | 'variant', name: string) {
    const dialogRef = this.dialog.open(DeleteProductDialogComponent, {
      width: '400px',
      data: { id, type, name } as DeleteDialogData
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
         // Optionally close the expanded view if a product is deleted
         if (type === 'product' && this.expandedProductId === id) {
           this.expandedProductId = null;
         }

         if (type === 'product') {
           this.getTotalProductCount();
         }
         this.getProducts();
      }
    });
  }
}


