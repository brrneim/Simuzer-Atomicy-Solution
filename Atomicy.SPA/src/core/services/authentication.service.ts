import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User } from '../models/user';
import { BaseHttpClientService } from './base-http-client.service';
import { ApiConfig } from '../configs/url.config';
import { LoginRequest } from '../models/loginRequest';

@Injectable()
export class AuthenticationService {
  private currentUserSubject!: BehaviorSubject<User>;
  public currentUser!: Observable<User> | null;

  constructor(private httpBaseService: BaseHttpClientService) {
    let userStorage: string | null = localStorage.getItem('currentUser');
    if (userStorage) {
      this.currentUserSubject! = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser') ?? ''));
      this.currentUser = this.currentUserSubject.asObservable();
    } else {
      this.currentUserSubject! = new BehaviorSubject<User>(new User());
      this.currentUser = null; //this.currentUserSubject.asObservable();
    }
  }

  public get currentUserValue(): User {
    return this.currentUserSubject && this.currentUserSubject.value ? this.currentUserSubject.value : new User();
  }
  public get hasCurrentUser(): any {
    return this.currentUser == null ?  null : this.currentUserSubject.value ;
  }
  login(username: string, password: string) {
    debugger;
    let loginRequest = new LoginRequest();
    loginRequest.email = username;
    loginRequest.password = password;
    var url = ApiConfig.baseUrl + ApiConfig.baseAuthPath + ApiConfig.authenticatePath;
    return this.httpBaseService.post<any>(url, loginRequest)
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user ) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          let authenticatedUser = new User();
          authenticatedUser.id = user.id;
          authenticatedUser.email = user.email ;
          authenticatedUser.token = user.token;
          authenticatedUser.username = user.username;
          authenticatedUser.firm = user.firm;
          this.currentUserSubject.next(authenticatedUser);
          this.currentUser = this.currentUserSubject.asObservable();
        }

        return user;
      }));
  }
  isLoggedIn(): boolean {
    let userStorage: string | null = localStorage.getItem('currentUser');
    if (userStorage) {
      this.currentUserSubject! = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser') ?? ''));
      this.currentUser = this.currentUserSubject.asObservable();
    } else {
      this.currentUserSubject! = new BehaviorSubject<User>(new User());
      this.currentUser = null; //this.currentUserSubject.asObservable();
    }
    return !!this.hasCurrentUser;
}
  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(new User());
    this.currentUser = null;
  }

  register(user: User, isFirm: boolean) {
    user.firm = isFirm;

    var url = ApiConfig.baseUrl + ApiConfig.baseAuthPath + ApiConfig.registerPath;
    return this.httpBaseService.post(url, user);
  }
}
