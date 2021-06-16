import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HeroesServerService } from '../../shared/fetch/heroes-server.service';
import { Color } from '../hero-card/hero-card.component';

@Component({
  selector: 'app-create-hero',
  templateUrl: './create-hero.component.html',
  styleUrls: ['./create-hero.component.css']
})
export class CreateHeroComponent implements OnInit {
  colors: string[] = []

  constructor(private heroesServerService: HeroesServerService, private router: Router) {
    for (var enumMember in Color) {
      var isValueProperty = parseInt(enumMember, 10) >= 0
      if (isValueProperty) {
        this.colors.push(Color[enumMember]);
      }
    }
  }

  ngOnInit(): void {
  }

  onSubmit(formData: NgForm) {
    if (formData.form.value.IsAttacker == '')
      formData.form.value.IsAttacker = false;
    this.heroesServerService.createHero(formData.form.value).subscribe(isSuccess => {
      if (isSuccess)
        this.router.navigate(['/heroScreen'])
      else
        console.log("Hero creation failed!")
    })
  }


}
