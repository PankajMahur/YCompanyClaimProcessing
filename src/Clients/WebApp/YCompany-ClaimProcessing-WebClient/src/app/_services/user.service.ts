import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PolicyUser } from '../models/PolicyUser'

const API_URL = 'http://localhost:9050';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  policyUser : PolicyUser;

  constructor(private http: HttpClient) {

   }

  getPublicContent(): Observable<any> {
    return this.http.get(API_URL + 'all', { responseType: 'text' });
  }

  getUserClaims(): Observable<any> {
    return this.http.get(API_URL + 'getClaim/' + this.policyUser.customerId, { responseType: 'json' });
  }

  getModeratorBoard(): Observable<any> {
    return this.http.get(API_URL + 'mod', { responseType: 'text' });
  }

  getAdminBoard(): Observable<any> {
    return this.http.get(API_URL + 'admin', { responseType: 'text' });
  }
}
