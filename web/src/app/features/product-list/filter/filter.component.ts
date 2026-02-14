import { Component, EventEmitter, Inject, Input, input, Output } from '@angular/core';
import { Category } from '../../../shared/models/category';
import { productParams } from '../../../shared/models/productParams';

@Component({
  selector: 'app-filter',
  imports: [],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.scss',
})
export class FilterComponent {
  @Input() categories: Category[] = [];
  @Input() groupedBrands: BrandGroup[] = [];
  @Input() productParams!: productParams;


   @Output() categoryFilterChange = new EventEmitter<string[]>();
   @Output() brandFilterChange = new EventEmitter<string[]>();


  onCategoryChange(category: string, isChecked: boolean) {
    if (isChecked) {
      this.productParams.category.push(category);
    } else {
      const index = this.productParams.category.indexOf(category);
      if (index > -1) {
        this.productParams.category.splice(index, 1);
      }

      this.productParams.pageSize = this.productParams.defaultPageSize;
    }
    // 3. Emit the updated list to the parent
    this.categoryFilterChange.emit(this.productParams.category);
  }
  onBrandChange(brand: string, isChecked: boolean) {
    if (isChecked) {
      this.productParams.brand.push(brand);
    } else {
      const index = this.productParams.brand.indexOf(brand);
      if (index > -1) {
        this.productParams.brand.splice(index, 1);
      }
      this.productParams.pageSize = this.productParams.defaultPageSize;
    }
    // 3. Emit the updated list to the parent
   this.brandFilterChange.emit(this.productParams.brand);

  }
  onResetFilters() {
    this.productParams.category = [];
    this.productParams.brand = [];
    this.productParams.pageSize = this.productParams.defaultPageSize;
    // Emit empty lists to clear filters in parent
   this.categoryFilterChange.emit([]);
    this.brandFilterChange.emit([]);
  }


}
