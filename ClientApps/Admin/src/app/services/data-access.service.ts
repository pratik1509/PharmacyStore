import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataAccessService {
  constructor(private client: HttpClient) {}
  DATA_ACCESS_PREFIX = 'http://localhost:54562/Api';
  private extractData(res: Response) {
    const body = res;
    return body || {};
  }

  getDoctors(): Observable<any> {
    return this.client.post(`${this.DATA_ACCESS_PREFIX}/Doctor/GetAllWithPagging`, {}).pipe(map(this.extractData));
  }
}
