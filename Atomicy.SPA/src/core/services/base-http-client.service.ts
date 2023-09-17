import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";

import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class BaseHttpClientService {
  constructor(private http: HttpClient) { }

  public get<T>(url: string): Observable<T> {
    const expandedHeaders = this.prepareHeader();
    return this.http
      .get<T>(url, expandedHeaders)
      .pipe(
        map(res => {
          return res;
        })
      );
  }

  public getWithBlob<T>(url: string): Observable<T> {
    const expandedHeaders = this.prepareHeader();
    const options = { expandedHeaders, responseType: 'blob' as 'json' };
    return this.http
      .get<T>(url, options)
      .pipe(
        map(res => {
          return res;
        })
      );
  }


  public post<T>(url: string, param: any): Observable<T> {
    const expandedHeaders = this.prepareHeader();
    return this.http
      .post<T>(url, param, expandedHeaders)
      .pipe(
        tap(res => {
          return res;
        })
      );
  }

  public postWithoutContentType<T>(url: string, param: any): Observable<T> {
    const expandedHeaders = this.prepareHeaderWithoutContentType();
    return this.http
      .post<T>(url, param, expandedHeaders)
      .pipe(
        tap(res => {
          return res;
        })
      );
  }

  public put<T>(url: string, param: any): Observable<HttpResponse<T>> {
    return this.http
      .put<T>(url, param, { observe: "response" })
      .pipe(
        tap(res => {
          return res;
        })
      );
  }

  public patch<T>(url: string, req:any): Observable<HttpResponse<T>> {
    const expandedHeaders = this.prepareHeader();
    let param = JSON.stringify(req);
    return this.http
      .patch<HttpResponse<T>>(url, param, expandedHeaders)
      .pipe(
        map(res => {
          return res;
        })
      );
  }

  public delete<T>(url: string): Observable<HttpResponse<T>> {
    return this.http
      .delete<T>(url, { observe: "response" })
      .pipe(
        tap(resp => {
          return resp;
        })
      );
  }

  private prepareHeader(): object {
    let headers: HttpHeaders = new HttpHeaders();
    headers = headers.set("Content-Type", "application/json");
    return {
      headers: headers
    };
  }

  private prepareHeaderWithoutContentType(): object {
    let headers: HttpHeaders = new HttpHeaders();
    return {
      headers: headers
    };
  }

  private prepareHeaderWithAllowOrigin(headers: HttpHeaders | null): object {
    headers = headers || new HttpHeaders();
    headers = headers.set("Accept", "application/json");
    headers = headers.set("Access-Control-Allow-Origin", "*");
    return {
      headers: headers
    };
  }

  public getWithToken<T>(url: string, accessToken: string): Observable<T> {
    const expandedHeaders = this.prepareHeaderWithToken(accessToken);
    return this.http
      .get<T>(url, expandedHeaders)
      .pipe(
        map(res => {
          return res;
        })
      );
  }

  private prepareHeaderWithToken(accessToken: string): object {
    let tokenHeader: string = 'Bearer ' + accessToken;
    let headers: HttpHeaders = new HttpHeaders();
    headers = headers.set("Content-Type", "application/json");
    headers = headers.set("Authorization", tokenHeader);
    return {
      headers: headers
    };
  }
}
