import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { User } from '../../shared/models/User';
import { Pagination } from '../../shared/models/pagination';
import { UserParams } from '../../shared/models/userParams';

@Injectable({
  providedIn: 'root'
})
export class UserManagementService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getUsers(userParams: UserParams) {
    let params = new HttpParams();

    if (userParams.search) {
      params = params.append('search', userParams.search);
    }

    if (userParams.roles && userParams.roles.length > 0) {
      params = params.append('roles', userParams.roles.join(','));
    }

    params = params.append('pageIndex', userParams.pageIndex);
    params = params.append('pageSize', userParams.pageSize);

    return this.http.get<Pagination<User>>(this.baseUrl + 'usermanage', { params });
  }

  promoteUser(userId: string, role: string) {
    return this.http.post(this.baseUrl + 'usermanage/promote', { userId, role });
  }
}
