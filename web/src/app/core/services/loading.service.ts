import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  loading = false;
  loadingRequestCount = 0;

  start(){
    this.loadingRequestCount++;
    this.loading = true
  }
  stop(){
    this.loadingRequestCount--;
    if(this.loadingRequestCount <= 0){
      this.loadingRequestCount = 0;
      this.loading = false;
    }

  }



}
