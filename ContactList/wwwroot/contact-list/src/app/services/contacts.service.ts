import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Contact } from '../models/contact';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(
    private http: HttpClient,
    private userService: UserService
    ) { }

    getAll() {
      const headers = new HttpHeaders({
        'Authorization': `Bearer ${this.userService.tokenValue.token}`
      })
      return this.http.get<Contact[]>(`${environment.apiUrl}/contact`, {headers} );
    }
}
