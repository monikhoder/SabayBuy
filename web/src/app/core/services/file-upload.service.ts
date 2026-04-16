import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FileUploadService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  imageUpload(file: File): Observable<{ url: string }> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post<{ url: string }>(`${this.baseUrl}files/upload`, formData);
  }

  deleteFile(fileUrl: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}files/delete`, {
      params: { fileUrl }
    });
  }
}
