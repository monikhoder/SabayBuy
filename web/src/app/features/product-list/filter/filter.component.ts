import { Component, EventEmitter, Input, input, Output } from '@angular/core';
import { Category } from '../../../shared/models/category';

@Component({
  selector: 'app-filter',
  imports: [],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.scss',
})
export class FilterComponent {
  @Input() categories: Category[] = [];
  @Input() groupedBrands: BrandGroup[] = [];

  selectedCategories: string[] = [];
  selectedBrands: string[] = [];

  @Output() categoryFilterChange = new EventEmitter<string[]>();
  @Output() brandFilterChange = new EventEmitter<string[]>();


  onCategoryChange(category: string, isChecked: boolean) {
    if (isChecked) {
      this.selectedCategories.push(category);
    } else {
      const index = this.selectedCategories.indexOf(category);
      if (index > -1) {
        this.selectedCategories.splice(index, 1);
      }
    }
    // 3. Emit the updated list to the parent
    this.categoryFilterChange.emit(this.selectedCategories);
  }
  onBrandChange(brand: string, isChecked: boolean) {
    if (isChecked) {
      this.selectedBrands.push(brand);
    } else {
      const index = this.selectedBrands.indexOf(brand);
      if (index > -1) {
        this.selectedBrands.splice(index, 1);
      }
    }
    // 3. Emit the updated list to the parent
    this.brandFilterChange.emit(this.selectedBrands);
  }
  onResetFilters() {
    this.selectedCategories = [];
    this.selectedBrands = [];
    // Emit empty lists to clear filters in parent
    this.categoryFilterChange.emit([]);
    this.brandFilterChange.emit([]);
  }

}
