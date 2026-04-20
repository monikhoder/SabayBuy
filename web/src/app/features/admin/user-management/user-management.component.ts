import { Component, inject, OnInit } from '@angular/core';
import { UserManagementService } from '../../../core/services/user-management.service';
import { User } from '../../../shared/models/User';
import { UserParams } from '../../../shared/models/userParams';
import { Pagination } from '../../../shared/models/pagination';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { PromoteUserDialogComponent } from './promote-user-dialog/promote-user-dialog.component';

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatIconModule,
    MatPaginatorModule,
    MatDialogModule,
    MatButtonModule
  ],
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.scss'
})
export class UserManagementComponent implements OnInit {
  private userManagementService = inject(UserManagementService);
  private dialog = inject(MatDialog);
  private snack = inject(SnackbarService);

  users: User[] = [];
  userParams = new UserParams();
  totalItems = 0;
  roles = ['Admin', 'Stock', 'Seller', 'Customer'];

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userManagementService.getUsers(this.userParams).subscribe({
      next: (response: Pagination<User>) => {
        this.users = response.data;
        this.totalItems = response.count;
      },
      error: (error) => this.snack.error(error.message)
    });
  }

  onSearch(value: string) {
    this.userParams.search = value;
    this.userParams.pageIndex = 1;
    this.getUsers();
  }

  handlePageEvent(event: PageEvent) {
    this.userParams.pageIndex = event.pageIndex + 1;
    this.userParams.pageSize = event.pageSize;
    this.getUsers();
  }

  openPromoteDialog(user: User) {
    const dialogRef = this.dialog.open(PromoteUserDialogComponent, {
      width: '400px',
      data: { user, roles: this.roles }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.userManagementService.promoteUser(user.id, result).subscribe({
          next: () => {
            this.snack.success(`User ${user.email} promoted to ${result} successfully`);
            this.getUsers();
          },
          error: (error) => this.snack.error(error.error || error.message)
        });
      }
    });
  }
}
