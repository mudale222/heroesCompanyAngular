import { NgStyle } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ModalService } from './modal.service';
declare var $: any;

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  @Input() modalTitle!: string
  @Input() modalText!: string
  @Input() modalStyle: any 
  constructor(private modalService: ModalService) { }

  ngOnInit(): void {
    this.modalService.modalSubject.subscribe(modalData => {
      this.modalText = modalData.text
      this.modalTitle = modalData.title
      if (modalData.color)
        this.modalStyle = this.setMyStyles(modalData.color)
      $('#centerModal').modal('toggle')
    })
  }

  close() {
    $('#centerModal').modal('toggle') //#5fd24aa3
  }

  setMyStyles(color:string) {
    let styles = {
      'backgroud': color ,
    };
    return styles;
  }
}
