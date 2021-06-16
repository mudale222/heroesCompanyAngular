import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { LoginData, RegistrtionData, ServerResponse } from '../models/models.component';

@Injectable({
  providedIn: 'root'
})
export class AccountServerService {

  private baseUrl: string

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private authService: AuthService ) {
    this.baseUrl = baseUrl
  }

  register(regData: RegistrtionData) {
    return this.http.post<ServerResponse>(this.baseUrl + 'Account/Create', regData)
  }

  login(loginData: LoginData) {
    return this.http.post<ServerResponse>(this.baseUrl + 'Account/login', loginData, { observe: 'response' }).pipe(tap(resData => {
      this.authService.setAuthenticated(resData.body!.isSuccessed)
    }))
  }

  logOut() {
    return this.http.post<ServerResponse>(this.baseUrl + 'Account/logout', {observe: 'response' }).pipe(tap(logOut => {
      this.authService.setAuthenticated(!logOut.isSuccessed)
    }))
  }
}
