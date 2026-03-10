import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Address, User } from '../../shared/models/User';
import {of} from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AccountService{
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null);


  login(values: any) {
    let params = new HttpParams();
    params = params.append('useCookies', true);
    return this.http.post<User>(this.baseUrl + 'login', values, { params });
  }
  register(values: any) {
    return this.http.post(this.baseUrl + 'account/register', values);

  }
  getUser() {

    return this.http.get<User>(this.baseUrl + 'account/user-info').pipe(
      map(user => {
        this.currentUser.set(user);
        return user;
      }),
      catchError(error => {
      this.currentUser.set(null);
      return of(null);
    })
    )

  };
  logout() {
    return this.http.post(this.baseUrl + 'account/logout', {})
  }
  updateAddress(address: Address, id: string) {
    return this.http.put(this.baseUrl + 'account/address/' + id, address);
  }

}
