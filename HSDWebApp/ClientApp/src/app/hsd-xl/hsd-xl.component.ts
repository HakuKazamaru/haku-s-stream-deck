import { Injectable, Component, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ModalService } from '../modal/modal.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-hsd-xl',
  templateUrl: './hsd-xl.component.html',
})
export class HsdXlComponent {
  public buttonData = [
    [
      { row: 0, col: 0, buttonName: 'btn01', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\tada.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 1, buttonName: 'btn02', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Startup.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 2, buttonName: 'btn03', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Logon.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 3, buttonName: 'btn04', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Logoff Sound.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 4, buttonName: 'btn05', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Shutdown.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 5, buttonName: 'btn06', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Critical Stop.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 6, buttonName: 'btn07', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Error.wav', buttonIcon: '', buttonDescription: '' },
      { row: 0, col: 7, buttonName: 'btn08', buttonType: 1, buttonCommand: 'C:\\Windows\\Media\\Windows Default.wav', buttonIcon: '', buttonDescription: '' },
    ],
    [
      { row: 1, col: 0, buttonName: 'btn11', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 1, buttonName: 'btn12', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 2, buttonName: 'btn13', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 3, buttonName: 'btn14', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 4, buttonName: 'btn15', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 5, buttonName: 'btn16', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 6, buttonName: 'btn17', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 1, col: 7, buttonName: 'btn18', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
    ],
    [
      { row: 2, col: 0, buttonName: 'btn21', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 1, buttonName: 'btn22', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 2, buttonName: 'btn23', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 3, buttonName: 'btn24', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 4, buttonName: 'btn25', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 5, buttonName: 'btn26', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 6, buttonName: 'btn27', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 2, col: 7, buttonName: 'btn28', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
    ],
    [
      { row: 3, col: 0, buttonName: 'btn31', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 1, buttonName: 'btn32', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 2, buttonName: 'btn33', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 3, buttonName: 'btn34', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 4, buttonName: 'btn35', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 5, buttonName: 'btn36', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 6, buttonName: 'btn37', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { row: 3, col: 7, buttonName: 'btn38', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
    ],
  ];

  postUrl = 'https://localhost:64859/Sound';

  constructor(private http: HttpClient, private modal: ModalService) { }

  public clickButton(id: string, type: number, command: string) {
    console.log('clickButton ID     :' + id);
    console.log('clickButton Type   :' + type);
    console.log('clickButton Command:' + command);

    if (type === 1) {
      this.http.request(
        'GET',
        this.postUrl + '?' + 'filePath=' + command,
        { responseType: 'json' })
        .subscribe((data) => {
          console.log(data);
        }, error => {
          console.log(error);
        });
    }
  }

  public async rightClick(row: number, col: number) {
    console.log('clickButton row:' + row);
    console.log('clickButton col:' + col);

    this.modal.buttonData = this.buttonData[row][col];

    const res = await this.modal.open();

    console.log(`result = ` + res);

    if (res) {
      this.buttonData[row][col] = this.modal.buttonData;
      console.log(`buttonName = ` + this.buttonData[row][col].buttonName);
    }

    return false;
  }

}
