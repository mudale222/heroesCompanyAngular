import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  identitySessionCookieName: string = "idsrv.session"
  identityApplicationCookieName: string = ".AspNetCore.Identity.Application"

  autoLogin = (): boolean => {
    if (localStorage.getItem(this.identityApplicationCookieName) && localStorage.getItem(this.identitySessionCookieName)) {
      this.cookieService.set(this.identityApplicationCookieName, localStorage.getItem(this.identityApplicationCookieName)!)
      this.cookieService.set(this.identitySessionCookieName, localStorage.getItem(this.identitySessionCookieName)!)
      this.isAuthenticatedSubject.next(true)
      return true
    }
    this.isAuthenticatedSubject.next(false)
    return false
  }

  isAuthenticatedSubject = new BehaviorSubject<boolean>(false)

  constructor(private cookieService: CookieService) {
    this.autoLogin()
  }

  setAuthenticated(isAuthenticated: boolean) {
    this.isAuthenticatedSubject.next(isAuthenticated)
    if (!isAuthenticated) {
      this.cookieService.deleteAll()
      localStorage.clear()
    } else
      this.loginSuccess()
  }

  getIsAuthenticated() {
    return this.isAuthenticatedSubject.getValue()
  }

  loginSuccess() {
    let allCookies = this.cookieService.getAll()
    if (allCookies[this.identityApplicationCookieName] && allCookies[this.identitySessionCookieName]) {
      localStorage.setItem(this.identityApplicationCookieName, allCookies[this.identityApplicationCookieName])
      localStorage.setItem(this.identitySessionCookieName, allCookies[this.identitySessionCookieName])
    }
  }
}
