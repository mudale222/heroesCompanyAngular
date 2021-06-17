import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of, Subscription } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { HeroesServerService } from '../../shared/fetch/heroes-server.service';
import { ServerResponse } from '../../shared/models/models.component';
import { HeroCardData } from '../hero-card/hero-card.component';

@Injectable({
  providedIn: 'root'
})
export class HeroesFetchResolver implements Resolve<ServerResponse> {
  heroes: HeroCardData[] = []
  constructor(private heroesServerService: HeroesServerService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ServerResponse> {
    return this.heroesServerService.getHeroes().pipe(map(heroes => {
      return heroes.data 
    }))
  }
}
