import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiConfig } from '../config/api-config';
import { ContactInfoModel } from '../models/contact-info.model';
import { CreateContactInfoModel } from '../models/create-contact-info.model';
import { UpdateContactInfoModel } from '../models/update-contact-info.model';

@Injectable({
  providedIn: 'root',
})
export class ContactInfoService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<ContactInfoModel[]> {
    return this.http.get<ContactInfoModel[]>(ApiConfig.CONTACT_INFO_API);
  }

  get(id: number): Observable<ContactInfoModel> {
    return this.http.get<ContactInfoModel>(ApiConfig.CONTACT_INFO_API + '' + id);
  }

  create(obj: CreateContactInfoModel): Observable<ContactInfoModel> {
    return this.http.post<ContactInfoModel>(ApiConfig.CONTACT_INFO_API, obj);
  }

  update(obj: UpdateContactInfoModel): Observable<ContactInfoModel> {
    return this.http.put<ContactInfoModel>(ApiConfig.CONTACT_INFO_API, obj);
  }

  delete(id: number): Observable<HttpResponse<any>> {
    return this.http.delete<HttpResponse<any>>(
      ApiConfig.CONTACT_INFO_API + id.toString(),
      { observe: 'response' }
    );
  }
}