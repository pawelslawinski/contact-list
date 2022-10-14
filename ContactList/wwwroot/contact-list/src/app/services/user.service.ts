import { Injectable } from '@angular/core';
import { UserLogin, UserRegister } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject, map } from 'rxjs';
import { Router } from '@angular/router';
import { JwtToken } from '../models/jwt';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  private token! : JwtToken;

  constructor(
    private router: Router,
    private http: HttpClient
  ) {
      this.tokenValue = JSON.parse(localStorage.getItem('jwtToken')|| '{}');
   }

  public get tokenValue(): JwtToken {
    return this.token;
  }
  private set tokenValue(value :JwtToken){
    this.token = value
  }

  register(user: UserRegister) {
    return this.http.post(`${environment.apiUrl}/user/register`, user);
  }

  login(user: UserLogin) {
    return this.http.post(`${environment.apiUrl}/user/login`, user)
    .pipe(map(token => {
      // store jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('jwtToken', JSON.stringify(token));
      this.tokenValue = JSON.parse(localStorage.getItem('jwtToken')|| '{}')
      return token;
  }));
  }

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('jwtToken');
    this.token = new JwtToken;
    this.router.navigate(['/account/login']);
  }



}
