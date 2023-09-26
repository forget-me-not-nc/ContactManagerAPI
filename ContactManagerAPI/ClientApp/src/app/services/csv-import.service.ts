import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiConfig } from '../config/api-config';

@Injectable({
  providedIn: 'root',
})
export class CSVImportService {
  constructor(private http: HttpClient) { }

  import(file: FormData): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(
      ApiConfig.CSV_IMPORT_API, file,
      { observe: 'response' }
    );
  }
}