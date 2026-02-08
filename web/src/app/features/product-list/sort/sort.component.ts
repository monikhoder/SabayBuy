import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-sort',
  imports: [],
  templateUrl: './sort.component.html',
  styleUrl: './sort.component.scss',
})
export class SortComponent {

  selectedSort: string = 'dateDesc';
  @Output() sortChange = new EventEmitter<string>();

  sortOptions = [
    {name: 'Newest Arrivals', value: 'dateDesc'},
    {name: 'Oldest', value: 'dateAsc'},
    {name: 'Alphabetical A-Z', value: 'nameAsc'},
    {name: 'Alphabetical Z-A', value: 'nameDesc'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ]

  onSortChange(sortValue: string) {
    this.selectedSort = sortValue;
    this.sortChange.emit(this.selectedSort);
  }

}
