import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Address, User } from '../../shared/models/User';
import { of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { SignalrService } from './signalr.service';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  private signalrService = inject(SignalrService);
  currentUser = signal<User | null>(null);
  selectedAddress = signal<Address | null>(null);

  login(values: any) {
    let params = new HttpParams();
    params = params.append('useCookies', true);
    return this.http.post<User>(this.baseUrl + 'login', values, { params }).pipe(
     tap(() => this.signalrService.createHubConnection())
    )
  }
  register(values: any) {
    return this.http.post(this.baseUrl + 'account/register', values);
  }
  getUser() {
    return this.http.get<User>(this.baseUrl + 'account/user-info').pipe(
      map((user) => {
        this.currentUser.set(user);
        const defaultAddress = user.addresses?.find((addr) => addr.isDefault);
        if (defaultAddress) {
          this.selectedAddress.set(defaultAddress);
        } else if (user.addresses && user.addresses.length > 0) {
          this.selectedAddress.set(user.addresses[0]);
        } else {
          this.selectedAddress.set(null);
        }
        return user;
      }),
      catchError((error) => {
        this.currentUser.set(null);
        this.selectedAddress.set(null);
        return of(null);
      }),
    );
  }

  logout() {
    return this.http.post(this.baseUrl + 'account/logout', {}).pipe(
      tap(() => this.signalrService.stopHubConnection())
    )
  }
  addAddress(address: Address) {
    return this.http.post<User>(this.baseUrl + 'account/address', address);
  }
  isAdmin(){
    return this.currentUser()?.role === 'Admin';
  }
  updateAddress(address: Address, id: string) {
    return this.http.put(this.baseUrl + 'account/address/' + id, address);
  }
  deleteAddress(id: string) {
    return this.http.delete(this.baseUrl + 'account/address/' + id);
  }
  getAutState() {
    return this.http.get<{ isAuthenticated: boolean }>(this.baseUrl + 'account/is-authenticated');
  }

  updateProfile(values: { firstName: string, lastName: string, phoneNumber?: string }) {
    return this.http.put<User>(this.baseUrl + 'account/profile', values).pipe(
      tap(user => this.currentUser.set(user))
    );
  }

  updateProfilePicture(profileUrl: string) {
    return this.http.put<User>(this.baseUrl + 'account/profile-picture', { profileUrl }).pipe(
      tap(user => this.currentUser.set(user))
    );
  }

  changePassword(values: any) {
    return this.http.post(this.baseUrl + 'account/change-password', values);
  }
}
