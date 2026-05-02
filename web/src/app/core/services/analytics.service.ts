import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { AdminDashboard } from '../../shared/models/adminDashboard';

@Injectable({
  providedIn: 'root'
})
export class AnalyticsService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  getAdminDashboard() {
    return this.http.get<AdminDashboard>(this.baseUrl + 'adminDashboard');
  }
}
