import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(
    private http: HttpClient
    ) { }

    getAll() {
      return this.http.get<Contact[]>(`${environment.apiUrl}/contact`);
    }
}
