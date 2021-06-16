import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

export class ModalData {
  constructor(public title: string, public text: string, public color?:string) { }

}

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  modalSubject = new Subject<ModalData>()
  //modalBhSubject = new BehaviorSubject<boolean>(false)

  constructor() { }

  showModal(modalData: ModalData) {
    this.modalSubject.next(modalData)
  }
}
