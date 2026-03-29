import { Component, inject } from '@angular/core';
import { AccountService } from '../../../core/services/account.service';

@Component({
  selector: 'app-address',
  imports: [],
  templateUrl: './address.component.html',
  styleUrl: './address.component.scss',
})
export class AddressComponent {

  accountService = inject(AccountService);

}
