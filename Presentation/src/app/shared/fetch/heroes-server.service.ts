import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Subject } from 'rxjs';
import { CreateHeroData, DeleteHeroResponse, PowerUpdateResponse, ServerResponse } from '../models/models.component';




@Injectable({
  providedIn: 'root'
})
export class HeroesServerService {

  private baseUrl: string
  heroIdDeletedSubject = new Subject<string>()


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
  }

  createHero(createHeroData: CreateHeroData) {
    return this.http.post<ServerResponse>(this.baseUrl + 'Heroes/Create', createHeroData)
  }

  getHeroes() {
    return this.http.post<ServerResponse>(this.baseUrl + 'Heroes/GetHeroes', {})
  }

  deleteHero(heroCardId: { "Id": string }) {
    const options = {
      headers: new HttpHeaders(), body: heroCardId
    }
    return this.http.delete<ServerResponse>(this.baseUrl + 'Heroes/delete',options)
  }

  train(heroCardId: { "Id": string }) {
    return this.http.patch<ServerResponse>(this.baseUrl + 'Heroes/train', heroCardId)
  }
}
