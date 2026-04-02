import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { MatMenu, MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-sort',
  standalone: true,
  imports: [MatMenuModule, MatButtonModule, MatIconModule],
  templateUrl: './sort.component.html',
  styleUrl: './sort.component.scss',
})
export class SortComponent {
  @ViewChild('sortMenu', { static: true }) menu!: MatMenu;

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
