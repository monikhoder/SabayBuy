import { Component, inject, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../../core/services/account.service';
import { SnackbarService } from '../../../core/services/snackbar.service';
import { CheckoutService } from '../../../core/services/checkout.service';
import { Address } from '../../../shared/models/User';

@Component({
  selector: 'app-address',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './address.component.html',
  styleUrl: './address.component.scss',
})
export class AddressComponent implements OnInit {
  @Input() addressToEdit: Address | null = null;
  @Output() saveSuccess = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();

  private fb = inject(FormBuilder);
  private snack = inject(SnackbarService)
  accountService = inject(AccountService);
  checkoutService = inject(CheckoutService);
  addressForm: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.initializeForm();
    if (this.addressToEdit) {
      this.addressForm.patchValue(this.addressToEdit);
    }
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

  onCancel() {
    this.cancel.emit();
  }

  onSubmit() {
    if (this.addressForm.valid) {
      const address = {
        ...this.addressForm.value,
      };

      if (this.addressToEdit && this.addressToEdit.id) {
        this.accountService.updateAddress(address, this.addressToEdit.id).subscribe({
          next: () => {
            this.accountService.getUser().subscribe();
          },
          complete: () => {
            this.checkoutService.getAvailableShippingMethods(address.zipCode);
            this.snack.success('Address updated successfully');
            this.saveSuccess.emit();
          },
          error: (error) => {
              this.snack.error(error.error)
          }
        });
      } else {
        this.accountService.addAddress(address).subscribe({
          next: () => {
            this.accountService.getUser().subscribe(
            )
          },
          complete: () => {
            this.checkoutService.getAvailableShippingMethods(address.zipCode);
            this.snack.success('Address added successfully');
            this.addressForm.reset();
            this.saveSuccess.emit();
          },
          error: (error) => {
              this.snack.error(error.error)
          }
        });
      }
    }
  }
}
