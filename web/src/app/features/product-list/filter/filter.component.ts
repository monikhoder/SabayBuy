import { Component, Input, input } from '@angular/core';
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

}
