import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { HeroCardData } from '../hero-card/hero-card.component';
import { HeroesServerService } from '../../shared/fetch/heroes-server.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hero-screen',
  templateUrl: './hero-screen.component.html',
  styleUrls: ['./hero-screen.component.css']
})
export class HeroScreenComponent implements OnInit, OnDestroy {
  heroes: HeroCardData[] = []
  subscriptionToHeroIdDeleted: Subscription
  constructor(private heroesServerService: HeroesServerService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const herosUnformattedArr = this.route.snapshot.data['HeroesFetchResolver']
    this.heroes = []
    herosUnformattedArr.forEach((heroUnformattedData: any) => {
      this.heroes.push(new HeroCardData(
        heroUnformattedData.id,
        heroUnformattedData.name,
        heroUnformattedData.isAttacker,
        heroUnformattedData.initialTrainDate,
        heroUnformattedData.suitColor,
        heroUnformattedData.startingPower,
        heroUnformattedData.currentPower,
        heroUnformattedData.trainedDate,
        heroUnformattedData.trainedCount
      ))
    })
    //})

    this.subscriptionToHeroIdDeleted = this.heroesServerService.heroIdDeletedSubject.subscribe((heroDeletedId: string) => {
      this.heroes = this.heroes.filter(hero => hero.Id != heroDeletedId)
    })
  }

  ngOnDestroy() {
    this.subscriptionToHeroIdDeleted.unsubscribe()
  }
}
