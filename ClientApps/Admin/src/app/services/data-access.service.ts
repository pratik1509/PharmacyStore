import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataAccessService {
  constructor(private http: HttpClient) {}
  DATA_ACCESS_PREFIX = 'http://localhost:54562/Api';
  private extractData(res: Response) {
    const body = res;
    return body || {};
  }

  public get(route: string) {
    return this.http.get(this.createCompleteRoute(route));
  }

  public post(route: string, body) {
    return this.http.post(this.createCompleteRoute(route), body, this.generateHeaders());
  }

  public put(route: string, body) {
    return this.http.put(this.createCompleteRoute(route), body, this.generateHeaders());
  }

  public delete(route: string) {
    return this.http.delete(this.createCompleteRoute(route));
  }

  getDoctors() {
    return this.http.post(`${this.DATA_ACCESS_PREFIX}/Doctor/GetAllWithPagging`, {});
  }
  private createCompleteRoute(route: string) {
    return `${this.DATA_ACCESS_PREFIX}/${route}`;
  }

  private generateHeaders() {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
  }
}
