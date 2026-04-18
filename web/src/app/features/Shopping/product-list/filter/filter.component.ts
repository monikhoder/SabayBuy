import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDividerModule } from '@angular/material/divider';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Category } from '../../../../shared/models/category';
import { productParams } from '../../../../shared/models/productParams';

export interface BrandGroup {
  letter: string;
  brands: string[];
}

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [
    CommonModule,
    MatTabsModule,
    MatCheckboxModule,
    MatSliderModule,
    MatButtonModule,
    MatIconModule,
    MatExpansionModule,
    MatDividerModule,
    FormsModule
  ],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.scss',
})
export class FilterComponent {
  @Input() categories: Category[] = [];
  @Input() groupedBrands: BrandGroup[] = [];
  @Input() productParams!: productParams;

  @Output() categoryFilterChange = new EventEmitter<string[]>();
  @Output() brandFilterChange = new EventEmitter<string[]>();
  @Output() applyFilters = new EventEmitter<void>();

  isOpen = false;

  toggleModal() {
    this.isOpen = !this.isOpen;
  }

  isAllSubcategoriesSelected(category: Category): boolean {
    const isParentSelected = this.productParams.category.includes(category.categoryName);
    if (!category.subCategories || category.subCategories.length === 0) {
      return isParentSelected;
    }
    const areAllSubsSelected = category.subCategories.every(sub => this.productParams.category.includes(sub.categoryName));
    return isParentSelected && areAllSubsSelected;
  }

  isSomeSubcategoriesSelected(category: Category): boolean {
    const isParentSelected = this.productParams.category.includes(category.categoryName);
    if (!category.subCategories || category.subCategories.length === 0) {
      return false;
    }
    const areSomeSubsSelected = category.subCategories.some(sub => this.productParams.category.includes(sub.categoryName));
    
    const hasAnySelection = isParentSelected || areSomeSubsSelected;
    return hasAnySelection && !this.isAllSubcategoriesSelected(category);
  }

  toggleAllSubcategories(category: Category, isChecked: boolean) {
    if (isChecked) {
      // Add parent category
      if (!this.productParams.category.includes(category.categoryName)) {
        this.productParams.category.push(category.categoryName);
      }
      // Add all subcategories that are not already in the array
      if (category.subCategories) {
        category.subCategories.forEach(sub => {
          if (!this.productParams.category.includes(sub.categoryName)) {
            this.productParams.category.push(sub.categoryName);
          }
        });
      }
    } else {
      // Remove parent category
      const parentIndex = this.productParams.category.indexOf(category.categoryName);
      if (parentIndex > -1) {
        this.productParams.category.splice(parentIndex, 1);
      }
      // Remove all subcategories
      if (category.subCategories) {
        category.subCategories.forEach(sub => {
          const index = this.productParams.category.indexOf(sub.categoryName);
          if (index > -1) {
            this.productParams.category.splice(index, 1);
          }
        });
      }
    }
    
    // Create a new array reference to trigger change detection if needed
    this.productParams.category = [...this.productParams.category];
    this.categoryFilterChange.emit(this.productParams.category);
  }

  onCategoryChange(category: string, isChecked: boolean) {
    if (isChecked) {
      this.productParams.category.push(category);
    } else {
      const index = this.productParams.category.indexOf(category);
      if (index > -1) {
        this.productParams.category.splice(index, 1);
      }
    }
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
    }
    this.brandFilterChange.emit(this.productParams.brand);
  }

  onResetFilters() {
    this.productParams.category = [];
    this.productParams.brand = [];
    this.categoryFilterChange.emit([]);
    this.brandFilterChange.emit([]);
  }

  onApply() {
    this.applyFilters.emit();
    this.toggleModal();
  }
}
