import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountServerService } from '../../shared/fetch/account-server.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  @Input() signupMeassage: string

  constructor(private accountServerService: AccountServerService, private router: Router) {
    this.signupMeassage = ''
  }

  ngOnInit(): void {
  }

  onSubmit(formData: NgForm) {
    console.log(formData.form.value)
    console.log(formData.form.valid)
    this.accountServerService.register(formData.form.value).subscribe(result => {
      if (result.isSuccessed) {
        this.signupMeassage = ''
        this.router.navigate(['/'])
      }
      else {
        this.signupMeassage = 'ERROR ' + JSON.stringify(result.error.errorMessage)
      }
    }, res => {
      this.signupMeassage = 'ERROR ' + JSON.stringify(res.error.error.errorMessage)
      console.error('error', res);
    })
  }
}
