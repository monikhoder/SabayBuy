import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../../core/services/account.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { FileUploadService } from '../../../core/services/file-upload.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit {
  private fb = inject(FormBuilder);
  accountService = inject(AccountService);
  private snack = inject(SnackbarService);
  private fileService = inject(FileUploadService);

  profileForm: FormGroup = new FormGroup({});
  passwordForm: FormGroup = new FormGroup({});
  isUpdatingProfile = false;
  isChangingPassword = false;
  isUploadingImage = false;

  ngOnInit(): void {
    this.createProfileForm();
    this.createPasswordForm();
    this.loadUserInfo();
  }

  createProfileForm() {
    this.profileForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: [{ value: '', disabled: true }],
      phoneNumber: ['']
    });
  }

  createPasswordForm() {
    this.passwordForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, { validators: this.passwordMatchValidator });
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('newPassword')?.value === g.get('confirmPassword')?.value
      ? null : { mismatch: true };
  }

  loadUserInfo() {
    const user = this.accountService.currentUser();
    if (user) {
      this.profileForm.patchValue({
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email,
        phoneNumber: '' // Add phoneNumber to user model if available
      });
    }
  }

  onUpdateProfile() {
    if (this.profileForm.invalid) return;
    this.isUpdatingProfile = true;
    this.accountService.updateProfile(this.profileForm.value).subscribe({
      next: () => {
        this.snack.success('Profile updated successfully');
        this.isUpdatingProfile = false;
      },
      error: (err) => {
        this.snack.error(err.error?.title || 'Failed to update profile');
        this.isUpdatingProfile = false;
      }
    });
  }

  onChangePassword() {
    if (this.passwordForm.invalid) return;
    this.isChangingPassword = true;
    this.accountService.changePassword(this.passwordForm.value).subscribe({
      next: () => {
        this.snack.success('Password changed successfully');
        this.passwordForm.reset();
        this.isChangingPassword = false;
      },
      error: (err) => {
        this.snack.error(err.error?.title || 'Failed to change password');
        this.isChangingPassword = false;
      }
    });
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.isUploadingImage = true;
      this.fileService.imageUpload(file).subscribe({
        next: (response) => {
          this.accountService.updateProfilePicture(response.url).subscribe({
            next: () => {
              this.snack.success('Profile picture updated successfully');
              this.isUploadingImage = false;
            },
            error: (err) => {
              this.snack.error('Failed to update profile picture in account');
              this.isUploadingImage = false;
            }
          });
        },
        error: (err) => {
          this.snack.error('Failed to upload image');
          this.isUploadingImage = false;
        }
      });
    }
  }
}
