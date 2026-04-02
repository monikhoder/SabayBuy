import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../../core/services/account.service';

@Component({
  selector: 'app-address',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './address.component.html',
  styleUrl: './address.component.scss',
})
export class AddressComponent implements OnInit {
  private fb = inject(FormBuilder);
  accountService = inject(AccountService);
  addressForm: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.addressForm = this.fb.group({
      fullName: ['', Validators.required],
      line1: ['', Validators.required],
      line2: [''],
      phoneNumber: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zipCode: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      country: ['', Validators.required],
      isDefault: [false]
    });
  }

  onSubmit() {
    if (this.addressForm.valid) {
      const address = {
        ...this.addressForm.value,
        zipCode: parseInt(this.addressForm.value.zipCode)
      };
      this.accountService.addAddress(address).subscribe({
        next: (user) => {
          this.accountService.currentUser.set(user);
          this.addressForm.reset({
            isDefault: false
          });
        }
      });
    }
  }
}
