import { Component, inject, OnInit } from '@angular/core';
import { Category } from '../../../shared/models/category';
import { Pagination } from '../../../shared/models/pagination';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIcon } from "@angular/material/icon";
import { AdminService } from '../../../core/services/admin.service';
import { categoryParams } from '../../../shared/models/categoryParams';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { AddCategoryDialogComponent } from './add-category-dialog/add-category-dialog.component';
import { UpdateCategoryDialogComponent } from './update-category-dialog/update-category-dialog.component';
import { SnackbarService } from '../../../core/services/snackbar.service';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { DeleteCategoryDialogComponent } from './delete-category-dialog/delete-category-dialog.component';
import { ShopServices } from '../../../core/services/shop.service';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [CommonModule, FormsModule, MatIcon, MatPaginatorModule, MatCheckboxModule, MatDialogModule, MatButtonModule],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss',
})
export class CategoriesComponent implements OnInit {
  adminService = inject(AdminService);
  shopService = inject(ShopServices);
  dialog = inject(MatDialog);
  snack = inject(SnackbarService)

  categories: Category[] = [];
  categoryParams = new categoryParams();
  totalItems = 0;

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.shopService.getCategories(this.categoryParams).subscribe({
      next: (response: Pagination<Category>) => {
        this.categories = response.data;
        this.totalItems = response.count;
      },
      error: (error) => this.snack.error(error.message)
    });
  }

  onSearch(value: string) {
    this.categoryParams.search = value;
    this.categoryParams.pageIndex = 1;
    this.getCategories();
  }

  onIsParentChange() {
    this.categoryParams.pageIndex = 1;
    this.getCategories();
  }

  handlePageEvent(event: any) {
    this.categoryParams.pageIndex = event.pageIndex + 1; // MatPaginator is 0-based
    this.categoryParams.pageSize = event.pageSize;
    this.getCategories();
  }

  openAddCategoryDialog() {
    const dialogRef = this.dialog.open(AddCategoryDialogComponent, {
      width: '500px',
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.snack.success(`Category "${result.categoryName}" added successfully`);
        this.getCategories();
      }
    });
  }

  openUpdateCategoryDialog(category: Category) {
    const dialogRef = this.dialog.open(UpdateCategoryDialogComponent, {
      width: '500px',
      data: category,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.snack.success(`Category "${result.categoryName}" updated successfully`);
        this.getCategories();
      }
    });
  }

  confirmDelete(category: Category) {
    const dialogRef = this.dialog.open(DeleteCategoryDialogComponent, {
      width: '350px',
      data: category
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.snack.success(`Category "${category.categoryName}" deleted successfully`);
        this.getCategories();
      }
    });
  }
}

