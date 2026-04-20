import { Component, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { User } from '../../../../shared/models/User';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-promote-user-dialog',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatDialogModule,
    MatButtonModule
  ],
  templateUrl: './promote-user-dialog.component.html',
  styleUrl: './promote-user-dialog.component.scss'
})
export class PromoteUserDialogComponent {
  readonly dialogRef = inject(MatDialogRef<PromoteUserDialogComponent>);
  readonly data = inject<{user: User, roles: string[]}>(MAT_DIALOG_DATA);

  selectedRole: string = this.data.user.role;

  onNoClick(): void {
    this.dialogRef.close();
  }

  confirm(): void {
    this.dialogRef.close(this.selectedRole);
  }
}
