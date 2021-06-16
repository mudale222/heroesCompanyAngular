import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AccountServerService } from '../shared/fetch/account-server.service';
import { AuthService } from '../shared/auth/auth.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isAuthenticated: boolean
  subscriptionIsAuthenticated!: Subscription

  constructor(private serverService: AccountServerService  ,private router: Router, private authService: AuthService) {
    this.isAuthenticated = false
    }

  ngOnInit(): void {
    this.subscriptionIsAuthenticated = this.authService.isAuthenticatedSubject.subscribe((isAuthenticated: boolean) => {
      this.isAuthenticated = isAuthenticated
    })
  }
  onLogout() {
    this.serverService.logOut().subscribe(resData => {
      if (resData)
        this.router.navigate(['/'])
    })
  }
}
