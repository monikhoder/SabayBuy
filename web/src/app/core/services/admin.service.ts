import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Pagination } from '../../shared/models/pagination';
import { AddCategory, Category } from '../../shared/models/category';
import { categoryParams } from '../../shared/models/categoryParams';


@Injectable({
  providedIn: 'root',
})
export class AdminService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getCategories(categoryParams: categoryParams) {
    let params = new HttpParams();

    if (categoryParams.search) {
      params = params.append('search', categoryParams.search);
    }
    if(categoryParams.isParent){
      params = params.append('isParent', categoryParams.isParent);
    }
    params = params.append('pageIndex', categoryParams.pageIndex);
    params = params.append('pageSize', categoryParams.pageSize);

    return this.http.get<Pagination<Category>>(this.baseUrl + 'categories', { params });
  }
  addCategory(category: AddCategory){
    return this.http.post<Category>(this.baseUrl + 'categories', category)
  }
  updateCategory(id: string, category: AddCategory) {
    return this.http.put<Category>(this.baseUrl + 'categories/' + id, category );
  }
  deleteCategory(id: string) {
    return this.http.delete(this.baseUrl + 'categories/' + id, { responseType: 'text' });
  }
}
