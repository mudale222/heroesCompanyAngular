import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { AccountServerService } from '../../shared/fetch/account-server.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Input() loginMeassage: string
  @Input() isInLoginProcess: boolean = false
  constructor(private accountServerService: AccountServerService, private router: Router) {
    this.loginMeassage = ''
  }

  ngOnInit(): void {
  }

  onSubmit(formData: NgForm) {
    this.isInLoginProcess = true
    this.accountServerService.login(formData.form.value).subscribe(result => {

      this.isInLoginProcess = false
      if (result.body!.isSuccessed) {
        this.loginMeassage = ''
        this.router.navigate(["/heroScreen"])
      }
      else {
        var msg: string = result.body!.error.errorMessage
        this.loginMeassage = 'ERROR, ' + msg
      }

    }, (res) => {
      this.loginMeassage = 'ERROR, ' + JSON.stringify(res.error.error.errorMessage)
      console.error('error', res)
      this.isInLoginProcess = false
    }
    )
  }
}
