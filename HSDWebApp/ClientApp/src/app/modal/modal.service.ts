import { Injectable, Component, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { ModalComponent } from './modal.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  public buttonData =
    {
      row: 0,
      col: 0,
      buttonName: '',
      buttonType: 0,
      buttonCommand: '',
      buttonIcon: '',
      buttonDescription: ''
    };

  constructor(private modalService: NgbModal) { }

  open(): Promise<boolean> {
    const modalRef = this.modalService.open(ModalComponent);
    const component = modalRef.componentInstance as ModalComponent;

    component.buttonRow = this.buttonData.row;
    component.buttonCol = this.buttonData.col;
    component.buttonName = this.buttonData.buttonName;
    component.buttonType = this.buttonData.buttonType;
    component.buttonCommand = this.buttonData.buttonCommand;
    component.buttonIcon = this.buttonData.buttonIcon;
    component.buttonDescription = this.buttonData.buttonDescription;

    return modalRef.result.then(result => {
      // はい を押したらこっち
      this.buttonData.row = component.buttonRow;
      this.buttonData.col = component.buttonCol;
      this.buttonData.buttonName = component.buttonName;
      this.buttonData.buttonType = component.buttonType;
      this.buttonData.buttonCommand = component.buttonCommand;
      this.buttonData.buttonIcon = component.buttonIcon;
      this.buttonData.buttonDescription = component.buttonDescription;

      console.log('[open]Name:' + this.buttonData.buttonName);

      return true;
    }, reason => {
      // いいえ や x でダイアログを閉じたらこっち
      return false;
    });
  }
}
