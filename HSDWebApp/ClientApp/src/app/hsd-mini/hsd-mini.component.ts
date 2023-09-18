import { Component } from '@angular/core';

@Component({
  selector: 'app-hsd-mini',
  templateUrl: './hsd-mini.component.html',
})
export class HsdMiniComponent {
  public buttonData = [
    [
      { buttonName: '', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { buttonName: '', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { buttonName: '', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
    ],
    [
      { buttonName: '', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { buttonName: '', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
      { buttonName: '', buttonType: 0, buttonCommand: '', buttonIcon: '', buttonDescription: '' },
    ],
  ];
}
