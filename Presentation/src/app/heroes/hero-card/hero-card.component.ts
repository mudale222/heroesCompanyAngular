import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { ModalService } from '../../shared/modal/modal.service';
import { HeroesServerService } from '../../shared/fetch/heroes-server.service';
import { ModalData } from '../../shared/modal/modal.service'
import { DeleteHeroResponse } from '../../shared/models/models.component';
import { error } from '@angular/compiler/src/util';

export enum Color {
  Red, Green, Blue, White, Black, Yellow, Grey
}
export class HeroCardData {

  constructor(
    public Id: string,
    public Name: string,
    public IsAttacker: boolean,
    public InitialTrainDate: string,
    public SuitColor: Color,
    public StartingPower: number,
    public CurrentPower: number,
    public TrainedDate: string,
    public TrainedCount: number
  ) {
    this.TrainedDate = this.formatDate(TrainedDate);
    this.InitialTrainDate = this.formatDate(InitialTrainDate);
  }

  formatDate(dateStr: string): string {
    let date = new Date(dateStr)
    return date.getUTCDate() + "/" + (date.getUTCMonth() + 1) + "/" + date.getUTCFullYear()
  }
}

@Component({
  selector: 'app-hero-card',
  templateUrl: './hero-card.component.html',
  styleUrls: ['./hero-card.component.css']
})

export class HeroCardComponent implements OnInit {
  @Input() hero: HeroCardData
  @Input() index: number
  @Input() color: Color

  constructor(private heroServerService: HeroesServerService, private modalService: ModalService) { }

  ngOnInit(): void {
  }

  onDelete(heroCardId: string) {
    if (confirm("R u sure u want to delete this hero?"))
      this.heroServerService.deleteHero({ "Id": heroCardId }).subscribe((response) => {
        if (response.isSuccessed) {
          this.modalService.showModal(new ModalData("Deleted Succeed!!", "Hero deleted.", "#5fd24aa3"))
          this.heroServerService.heroIdDeletedSubject.next(heroCardId)
        } else {
          this.modalService.showModal(new ModalData("ERROR", "Unfourtenly something went worng!!\n" + response.error.errorMessage, "#bd270596"))
        }
      })
  }

  onTrain(heroCardId: string) {
    this.heroServerService.train({ "Id": heroCardId }).subscribe(res => {
      if (res.isSuccessed) {
        let powerImprovePrecent = ((res.data.updatedPower / this.hero.CurrentPower) * 100 - 100).toFixed(2)
        alert("NICE! Your hero got stronger by " + powerImprovePrecent + "%!")
        this.hero.CurrentPower = res.data.updatedPower
        this.hero.TrainedCount++
      } else
        alert("Unfourtenly u can't train the same hero more then 5 times a day!")
    }, error => {
        alert(error.error.error.errorMessage)
    })
  }


}
